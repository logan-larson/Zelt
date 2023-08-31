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
    /// <summary>
    /// Visits statements.
    /// </summary>
    public class StatementVisitor : ZeltParserBaseVisitor<ZStatement>
    {
        /// <summary>
        /// The types known to this scope.
        /// </summary>
        private Dictionary<string, ZType> _types { get; set; } = new Dictionary<string, ZType>()
        {
            { "Int", ZType.Int },
            { "Float", ZType.Float },
            { "String", ZType.String },
            { "Bool", ZType.Bool },
            { "Null", ZType.Null }, // Temporary type, will be removed when I add structs
        };

        /// <summary>
        /// Represents the variables that are currently in scope.
        /// </summary>
        private Dictionary<string, ZVariable> _variables { get; set; } = new Dictionary<string, ZVariable>();

        /// <summary>
        /// The source code lines.
        /// </summary>
        private string[] _sourceCodeLines { get; set; }

        /// <summary>
        /// Represents the type of the variable that called the current function. It is null if the current function does not have a caller.
        /// </summary>
        private ZType _callerType { get; set; } = ZType.Null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatementVisitor"/> class.
        /// </summary>
        /// <param name="types">The types known to this scope.</param>
        /// <param name="variables">The variables known to this scope.</param>
        /// <param name="sourceCodeLines">The source code lines.</param>
        /// <param name="callerType">The type of the variable that called the current function. Null by default</param>
        public StatementVisitor(
            Dictionary<string, ZType> types,
            Dictionary<string, ZVariable> variables,
            string[] sourceCodeLines,
            ZType? callerType = null
        )
        {
            _types = types;
            _variables = variables;
            _sourceCodeLines = sourceCodeLines;
            _callerType = callerType ?? ZType.Null;
        }

        /// <summary>
        /// Visits a statement.
        /// </summary>
        /// <param name="context">The parser tree context.</param>
        /// <returns>A <see cref="ZStatement"/> node.</returns>
        public override ZStatement VisitStatement([NotNull] ZeltParser.StatementContext context)
        {
            var exprVisitor = new ExpressionVisitor(_types, _variables, _sourceCodeLines);

            var expr = exprVisitor.VisitExpression(context.expression());

            return new ZStatement(expr);
        }

        /*
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
                    // If the variable type is a struct, then we need to add the variable identifier to the types list
                    // Because the struct type is not defined until the assignment is made
                    if (assignment.Variable.Type is ZStructType)
                    {
                        Types[assignment.Variable.Name] = assignment.Variable.Type;
                    }

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
                    // If the variable type is a struct, then we need to add the variable identifier to the types list
                    // Because the struct type is not defined until the assignment is made
                    if (assignment.Variable.Type is ZStructType)
                    {
                        Types[assignment.Variable.Name] = assignment.Variable.Type;
                    }

                    Variables[assignment.Variable.Name] = assignment.Variable;
                }

                return new ZAssignmentStatement(assignments);
            }
            else if (context.simpleAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines, CallerType).VisitSimpleAssignment(context.simpleAssignment());

                foreach (ZAssignment assignment in assignments)
                {
                    // If the variable type is a struct, then we need to add the variable identifier to the types list
                    // Because the struct type is not defined until the assignment is made
                    if (assignment.Variable.Type is ZStructType)
                    {
                        Types[assignment.Variable.Name] = assignment.Variable.Type;
                    }
                }

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
        */
    }
}
