﻿using System.IO;
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

        public Dictionary<string, ZFunction> Functions { get; private set; } = new Dictionary<string, ZFunction>();
        public Dictionary<string, ZStruct> Structs { get; private set; } = new Dictionary<string, ZStruct>();
        public Dictionary<string, ZStructInstance> StructInstances { get; private set; } = new Dictionary<string, ZStructInstance>();

        public string[] SourceCodeLines { get; private set; }

        public StatementVisitor(
            Dictionary<string, ZType> types,
            Dictionary<string, ZVariable> variables,
            Dictionary<string, ZFunction> functions,
            Dictionary<string, ZStruct> structs,
            Dictionary<string, ZStructInstance> structInstances, 
            string[] sourceCodeLines
        )
        {
            Types = types;
            Variables = variables;
            Functions = functions;
            Structs = structs;
            StructInstances = structInstances;
            SourceCodeLines = sourceCodeLines;
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
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines).VisitAssignment(context.assignment());

                // Add assignments to the known variables
                foreach (ZAssignment assignment in assignments)
                {
                    Variables[assignment.Variable.Name] = assignment.Variable;
                }

                return new ZAssignmentStatement(assignments);
            }
            else if (context.inferAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines).VisitInferAssignment(context.inferAssignment());

                // Add assignments to the known variables
                foreach (ZAssignment assignment in assignments)
                {
                    Variables[assignment.Variable.Name] = assignment.Variable;
                }

                return new ZAssignmentStatement(assignments);
            }
            else if (context.simpleAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, Variables, SourceCodeLines).VisitSimpleAssignment(context.simpleAssignment());

                return new ZAssignmentStatement(assignments);
            }

            throw new NotImplementedException();
        }

        public override IZStatement VisitIfStatement([NotNull] ZeltParser.IfStatementContext context)
        {
            IZExpression condition = new ExpressionVisitor(Types, Variables, SourceCodeLines).VisitExpression(context.expression());

            // If the condition is not a boolean, throw an error
            if (condition.Type != ZType.Bool)
            {
                ErrorHandler.ThrowError("Condition must be a boolean", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            List<IZStatement> trueBody = new List<IZStatement>();
            List<IZStatement> falseBody = new List<IZStatement>();

            // Setup the scope for the true body
            StatementVisitor trueVisitor = new StatementVisitor(Types, Variables, Functions, Structs, StructInstances, SourceCodeLines);

            // If there is a true body, visit it
            if (context.block() != null)
            {
                foreach (var statement in context.block().statement())
                {
                    trueBody.Add(trueVisitor.Visit(statement));
                }
            }

            // Setup the scope for the false body
            StatementVisitor falseVisitor = new StatementVisitor(Types, Variables, Functions, Structs, StructInstances, SourceCodeLines);

            // If there is an else if statement, visit it in its own scope
            if (context.elseIfStatement() == null)
                return new ZIfStatement(condition, trueBody, falseBody);

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
                }
            }

            return new ZIfStatement(condition, trueBody, falseBody);
        }

        public override IZStatement VisitWhileStatement([NotNull] ZeltParser.WhileStatementContext context)
        {
            IZExpression condition = new ExpressionVisitor(Types, Variables, SourceCodeLines).VisitExpression(context.expression());

            // If the condition is not a boolean, throw an error
            if (condition.Type != ZType.Bool)
            {
                ErrorHandler.ThrowError("Condition must be a boolean", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            List<IZStatement> body = new List<IZStatement>();

            // Setup the scope for the body
            StatementVisitor visitor = new StatementVisitor(Types, Variables, Functions, Structs, StructInstances, SourceCodeLines);

            // If there is a body, visit it
            if (context.block() != null)
            {
                foreach (var statement in context.block().statement())
                {
                    body.Add(visitor.Visit(statement));
                }
            }

            return new ZWhileStatement(condition, body);
        }

        // TODO: Add support for lists before adding this
        public override IZStatement VisitEachStatement([NotNull] ZeltParser.EachStatementContext context)
        {
            return base.VisitEachStatement(context);
        }
    }
}