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

namespace Zelt.Visitors
{
    public partial class Visitor : ZeltParserBaseVisitor<object>
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


        public ZAST Root { get; private set; } = new ZAST();


        public override ZDeclarationStatement VisitDeclarationStatement([NotNull] ZeltParser.DeclarationStatementContext context)
        {
            List<ZDeclaration> declarations = new DeclarationVisitor(Types, Variables, SourceCodeLines).VisitDeclaration(context.declaration());

            Root.Statements.Add(new ZDeclarationStatement(declarations));

            return new ZDeclarationStatement(declarations);
        }

        // Visit each type of assignment

        public override ZAssignmentStatement VisitAssignmentStatement([NotNull] ZeltParser.AssignmentStatementContext context)
        {
            List<ZAssignment> assignments = new List<ZAssignment>();

            if (context.assignment() != null)
            {
                assignments = new AssignmentVisitor(Types, SourceCodeLines).VisitAssignment(context.assignment());

                Root.Statements.Add(new ZAssignmentStatement(assignments));

                return new ZAssignmentStatement(assignments);
            }
            else if (context.inferAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, SourceCodeLines).VisitInferAssignment(context.inferAssignment());

                Root.Statements.Add(new ZAssignmentStatement(assignments));

                return new ZAssignmentStatement(assignments);
            }
            else if (context.simpleAssignment() != null)
            {
                assignments = new AssignmentVisitor(Types, SourceCodeLines).VisitSimpleAssignment(context.simpleAssignment());

                Root.Statements.Add(new ZAssignmentStatement(assignments));

                return new ZAssignmentStatement(assignments);
            }

            throw new NotImplementedException();
        }

    }
}
