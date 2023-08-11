using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;
using Zelt.Grammar;

namespace Zelt.Visitors
{
    public class ProgramVisitor : ZeltParserBaseVisitor<ZProgram>
    {
        public Dictionary<string, ZType> Types { get; private set; } = new Dictionary<string, ZType>()
        {
            { "Int", ZType.Int },
            { "Float", ZType.Float },
            { "String", ZType.String },
            { "Bool", ZType.Bool },
            { "Null", ZType.Null },
        };

        // Global scope variables, functions, structs (type definitions)
        public Dictionary<string, ZVariable> Variables { get; private set; } = new Dictionary<string, ZVariable>();

        public string[] SourceCodeLines { get; private set; }

        public ProgramVisitor(string[] sourceCodeLines)
        {
            SourceCodeLines = sourceCodeLines;
        }

        public override ZProgram VisitProgram([NotNull] ZeltParser.ProgramContext context)
        {
            ZProgram program = new ZProgram();
            // Visit each statement in the program

            StatementVisitor statementVisitor = new StatementVisitor(Types, Variables, SourceCodeLines);

            foreach (ZeltParser.StatementContext statement in context.statement())
            {
                program.Statements.Add(statementVisitor.VisitStatement(statement));
            }

            /*
            // Add the main function
            program.Statements.Add(new ZFunctionCallStatement(new ZFunctionCall("main", new List<ZExpression>())));

            // Add the main function to the list of functions
            Functions.Add("main", new ZFunction("main", new List<ZVariable>(), ZType.Void, program.Statements));

            // Add the main function to the program
            program.Functions.Add(Functions["main"]);
            */

            // Type check the program
            TypeChecker.CheckVariableDeclarationTypes(Variables, SourceCodeLines);

            return program;
        }
    }
}
