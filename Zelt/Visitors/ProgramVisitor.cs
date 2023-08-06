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

        // This represents the variables that are currently in scope
        public Dictionary<string, ZVariable> Variables { get; private set; } = new Dictionary<string, ZVariable>();

        public Dictionary<string, ZFunction> Functions { get; private set; } = new Dictionary<string, ZFunction>();
        public Dictionary<string, ZStruct> Structs { get; private set; } = new Dictionary<string, ZStruct>();
        public Dictionary<string, ZStructInstance> StructInstances { get; private set; } = new Dictionary<string, ZStructInstance>();

        public string[] SourceCodeLines { get; private set; }

        public ProgramVisitor(string[] sourceCodeLines)
        {
            SourceCodeLines = sourceCodeLines;
        }


        public override ZProgram VisitProgram([NotNull] ZeltParser.ProgramContext context)
        {
            ZProgram program = new ZProgram();
            // Visit each statement in the program

            foreach (ZeltParser.StatementContext statement in context.statement())
            {
                program.Statements.Add(new StatementVisitor(Types, Variables, Functions, Structs, StructInstances, SourceCodeLines).VisitStatement(statement));
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
            TypeCheck();

            return program;
        }

        public void TypeCheck()
        {
            foreach (var variable in Variables)
            {
                if (!variable.Value.Type.IsDefined)
                {
                    ErrorHandler.ThrowError($"Variable '{variable.Value.Name}' type '{variable.Value.Type.Name}' was not defined.", variable.Value.Line, variable.Value.Column, SourceCodeLines);
                }
            }
        }
    }
}
