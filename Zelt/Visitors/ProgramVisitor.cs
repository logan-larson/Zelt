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
    /// <summary>
    /// Visits programs.
    /// </summary>
    public class ProgramVisitor : ZeltParserBaseVisitor<ZProgram>
    {
        /// <summary>
        /// The types known to this scope which is the global scope.
        /// </summary>
        private Dictionary<string, ZType> _types { get; set; } = new Dictionary<string, ZType>()
        {
            { "Int", ZType.Int },
            { "Float", ZType.Float },
            { "String", ZType.String },
            { "Bool", ZType.Bool },
            { "Null", ZType.Null },
        };

        /// <summary>
        /// The variables known to this scope which is the global scope.
        /// </summary>
        private Dictionary<string, ZVariable> _variables { get; set; } = new Dictionary<string, ZVariable>();

        /// <summary>
        /// The source code lines.
        /// </summary>
        private string[] _sourceCodeLines { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramVisitor"/> class.
        /// </summary>
        /// <param name="sourceCodeLines">The source code lines.</param>
        public ProgramVisitor(string[] sourceCodeLines)
        {
            _sourceCodeLines = sourceCodeLines;
        }

        /// <summary>
        /// Visits a program.
        /// </summary>
        /// <param name="context">The parser tree context.</param>
        /// <returns>A <see cref="ZProgram"/> node.</returns>
        public override ZProgram VisitProgram([NotNull] ZeltParser.ProgramContext context)
        {
            ZProgram program = new ZProgram();
            // Visit each statement in the program

            StatementVisitor statementVisitor = new StatementVisitor(_types, _variables, _sourceCodeLines);

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
            TypeChecker.CheckVariableDeclarationTypes(_variables, _sourceCodeLines);

            return program;
        }
    }
}
