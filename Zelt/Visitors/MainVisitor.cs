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

namespace Zelt.Visitors
{
    public partial class Visitor : ZeltParserBaseVisitor<object>
    {

        public Dictionary<string, ZType> Types { get; private set; } = new Dictionary<string, ZType>()
        {
            { "Int", new ZType("Int", null, true) },
            { "Float", new ZType("Float", null, true) },
            { "String", new ZType("String", null, true) },
            { "Bool", new ZType("Bool", null, true) },
            { "Null", new ZType("Null", null, true) }, // Temporary type, will be removed when I add structs
        };

        // This represents the variables that are currently in scope
        public Dictionary<string, ZVariable> Variables { get; private set; } = new Dictionary<string, ZVariable>();

        public Dictionary<string, ZFunction> Functions { get; private set; } = new Dictionary<string, ZFunction>();
        public Dictionary<string, ZStruct> Structs { get; private set; } = new Dictionary<string, ZStruct>();
        public Dictionary<string, ZStructInstance> StructInstances { get; private set; } = new Dictionary<string, ZStructInstance>();


        public ZAST Root { get; private set; } = new ZAST();


        public override ZDeclarationStatement VisitDeclarationStatement([NotNull] ZeltParser.DeclarationStatementContext context)
        {
            List<ZDeclaration> declarations = VisitDeclaration(context.declaration());

            Root.Statements.Add(new ZDeclarationStatement(declarations));

            return new ZDeclarationStatement(declarations);
        }

        public override List<ZDeclaration> VisitDeclaration([NotNull] ZeltParser.DeclarationContext context)
        {
            // Iterate through the identifiers and types

            // Get the identifiers
            List<string> identifiers = new List<string>();
            foreach (var identifier in context.identifierList().IDENTIFIER())
            {
                identifiers.Add(identifier.GetText());
            }

            foreach (var identifier in identifiers)
            {
                if (Variables.ContainsKey(identifier))
                {
                    // Variable already exists
                    ErrorHandler.ThrowError($"Variable '{identifier}' was already declared.", context.Start.Line, context.Start.Column);
                }

            }

            // Get the types
            List<ZType> types = new List<ZType>();
            foreach (var type in context.typeList().type())
            {
                types.Add(VisitType(type));
            }

            // Check if the number of identifiers and types match
            if (identifiers.Count != types.Count)
            {
                ErrorHandler.ThrowError($"Uneven number of names and types\nNames: {context.identifierList().ToInfoString}\nTypes: {context.typeList().ToInfoString}", context.Start.Line, context.Start.Column);
            }

            List<ZDeclaration> declarations = new List<ZDeclaration>();

            // Create the variables
            for (int i = 0; i < identifiers.Count; i++)
            {
                // All variables when declared are set to null, TODO: change to default value of type later
                // If I do this, that means every struct declaration will have to provide a default value for the struct
                var variable = new ZVariable(identifiers[i], types[i], null);

                Variables.Add(variable.Name, variable);

                declarations.Add(new ZDeclaration(variable));
            }

            return declarations;
        }


        public override ZType VisitType([NotNull] ZeltParser.TypeContext context)
        {
            // If the type is already defined, return it
            if (Types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
            {
                return type;
            }
            
            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null);

            Types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }
    }
}
