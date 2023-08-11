using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Zelt.Grammar;
using Zelt.AST;
using Antlr4.Runtime.Tree;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Zelt.Visitors
{
    public partial class StatementVisitor : ZeltParserBaseVisitor<IZStatement>
    {

        public Dictionary<string, ZType> Types { get; private set; } = new Dictionary<string, ZType>()
        {
            { "Int", ZType.Int },
            { "Float", ZType.Float },
            { "String", ZType.String },
            { "Bool", ZType.Bool },
            { "Null", ZType.Null }, // Temporary type, will be removed when I add structs
        };

        // This represents the variables that are currently in scope
        public Dictionary<string, ZVariable> Variables { get; private set; } = new Dictionary<string, ZVariable>();

        public string[] SourceCodeLines { get; private set; }

        // Used to keep track of the type of the variable that called the current function
        public ZType CallerType { get; private set; } = ZType.Null;

        public StatementVisitor(
            Dictionary<string, ZType> types,
            Dictionary<string, ZVariable> variables,
            string[] sourceCodeLines,
            ZType? callerType = null
        )
        {
            Types = types;
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
            CallerType = callerType ?? ZType.Null;
        }

        public override ZDeclarationStatement VisitDeclarationStatement([NotNull] ZeltParser.DeclarationStatementContext context)
        {
            List<ZDeclaration> declarations = new DeclarationVisitor(Types, Variables, SourceCodeLines).VisitDeclaration(context.declaration());

            return new ZDeclarationStatement(declarations);
        }

        public override ZAssignmentStatement VisitAssignmentStatement([NotNull] ZeltParser.AssignmentStatementContext context)
        {
            List<ZAssignment> assignments = new List<ZAssignment>();

            if (context.assignment() != null)
            {
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines, CallerType).VisitAssignment(context.assignment());

                // Add assignments to the known variables
                foreach (ZAssignment assignment in assignments)
                {
                    Variables[assignment.Variable.Name] = assignment.Variable;
                }

                return new ZAssignmentStatement(assignments);
            }
            else if (context.inferAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines, CallerType).VisitInferAssignment(context.inferAssignment());

                // Add assignments to the known variables
                foreach (ZAssignment assignment in assignments)
                {
                    Variables[assignment.Variable.Name] = assignment.Variable;
                }

                return new ZAssignmentStatement(assignments);
            }
            else if (context.simpleAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines, CallerType).VisitSimpleAssignment(context.simpleAssignment());

                return new ZAssignmentStatement(assignments);
            }

            throw new NotImplementedException();
        }


        public override IZStatement VisitReturnStatement([NotNull] ZeltParser.ReturnStatementContext context)
        {
            List<ZReturnValue> returnValues = new List<ZReturnValue>();

            if (context.expression() != null)
            {
                ExpressionVisitor expressionVisitor = new ExpressionVisitor(Types, Variables, SourceCodeLines, CallerType);
                foreach (var (expressionContext, position) in context.expression().Select((e, p) => (e, p)))
                {
                    IZExpression expression = expressionVisitor.VisitExpression(expressionContext);
                    returnValues.Add(new ZReturnValue(expression.Type, expression, position));
                }
            }

            return new ZReturnStatement(returnValues);
        }

        public override IZStatement VisitIfStatement([NotNull] ZeltParser.IfStatementContext context)
        {
            IZExpression condition = new ExpressionVisitor(Types, Variables, SourceCodeLines, CallerType).VisitExpression(context.expression());

            // If the condition is not a boolean, throw an error
            if (condition.Type != ZType.Bool)
            {
                ErrorHandler.ThrowError("Condition must be a boolean", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            List<IZStatement> trueBody = new List<IZStatement>();
            List<IZStatement> falseBody = new List<IZStatement>();

            // Setup the scope for the true body
            Dictionary<string, ZVariable> trueVariables = new Dictionary<string, ZVariable>(Variables);
            StatementVisitor trueVisitor = new StatementVisitor(Types, trueVariables, SourceCodeLines);

            // If there is a true body, visit it
            if (context.block() != null)
            {
                foreach (var statement in context.block().statement())
                {
                    trueBody.Add(trueVisitor.Visit(statement));
                }

                // Type check the body -- is this necessary?
                TypeChecker.CheckVariableDeclarationTypes(trueVariables, SourceCodeLines);
            }

            // If there isn't an else if statement, return the if statement
            if (context.elseIfStatement() == null)
                return new ZIfStatement(condition, trueBody, falseBody);

            // Setup the scope for the false body
            Dictionary<string, ZVariable> falseVariables = new Dictionary<string, ZVariable>(Variables);
            StatementVisitor falseVisitor = new StatementVisitor(Types, falseVariables, SourceCodeLines);

            if (context.elseIfStatement().ifStatement() != null)
            {
                // Setup if statement context
                ZeltParser.IfStatementContext ifStatementContext = context.elseIfStatement().ifStatement();

                // Visit the else if statement
                falseBody.Add(falseVisitor.VisitIfStatement(ifStatementContext));
            }
            // If there is an else statement, visit it in its own scope
            else if (context.elseIfStatement().block() != null)
            {
                // If there is an else body, visit it
                if (context.block().statement().Length > 0)
                {
                    foreach (var statement in context.block().statement())
                    {
                        falseBody.Add(falseVisitor.Visit(statement));
                    }

                    // Type check the body -- is this necessary?
                    TypeChecker.CheckVariableDeclarationTypes(falseVariables, SourceCodeLines);
                }
            }

            return new ZIfStatement(condition, trueBody, falseBody);
        }

        public override IZStatement VisitWhileStatement([NotNull] ZeltParser.WhileStatementContext context)
        {
            IZExpression condition = new ExpressionVisitor(Types, Variables, SourceCodeLines, CallerType).VisitExpression(context.expression());

            // If the condition is not a boolean, throw an error
            if (condition.Type != ZType.Bool)
            {
                ErrorHandler.ThrowError("Condition must be a boolean", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            List<IZStatement> body = new List<IZStatement>();

            // Setup the scope for the body
            Dictionary<string, ZVariable> bodyVariables = new Dictionary<string, ZVariable>(Variables);
            StatementVisitor visitor = new StatementVisitor(Types, bodyVariables, SourceCodeLines);

            // If there is a body, visit it
            if (context.block() != null)
            {
                foreach (var statement in context.block().statement())
                {
                    body.Add(visitor.Visit(statement));
                }

                // Type check the body -- is this necessary?
                TypeChecker.CheckVariableDeclarationTypes(bodyVariables, SourceCodeLines);
            }

            return new ZWhileStatement(condition, body);
        }

        public override IZStatement VisitEachStatement([NotNull] ZeltParser.EachStatementContext context)
        {

            // 0. Setup the scope for the iterating variables
            List<ZVariable> iteratingVariables = new List<ZVariable>();
            List<IZExpression> listsToIterate = new List<IZExpression>();

            Dictionary<string, ZVariable> eachVariables = new Dictionary<string, ZVariable>(Variables);

            // 1. Get the iterating variables
            foreach (var declaration in context.declarationList().declaration())
            {
                ZDeclaration iteratingVariable = new DeclarationVisitor(Types, eachVariables, SourceCodeLines).VisitDeclaration(declaration)[0];
                iteratingVariable.Variable.IsDefined = true;
                iteratingVariables.Add(iteratingVariable.Variable);
            }

            // 2. Get the lists to iterate over
            foreach (var list in context.expressionList().expression())
            {
                IZExpression listToIterate = new ExpressionVisitor(Types, eachVariables, SourceCodeLines, CallerType).VisitExpression(list);

                if (listToIterate is not ZListExpression)
                if (listToIterate.Type is not ZListType)
                {
                    ErrorHandler.ThrowError("Each statement must iterate over a list", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                listsToIterate.Add(listToIterate);
            }

            // 5. Visit the body

            // Setup the scope for the body
            List<IZStatement> body = new List<IZStatement>();
            Dictionary<string, ZVariable> bodyVariables = new Dictionary<string, ZVariable>(eachVariables);

            StatementVisitor visitor = new StatementVisitor(Types, eachVariables, SourceCodeLines);

            // If there is a body, visit it
            if (context.block() != null)
            {
                foreach (var statement in context.block().statement())
                {
                    body.Add(visitor.Visit(statement));
                }

                // Type check the body -- is this necessary?
                TypeChecker.CheckVariableDeclarationTypes(eachVariables, SourceCodeLines);
            }

            return new ZEachStatement(iteratingVariables, listsToIterate, body);
        }
    }
}
