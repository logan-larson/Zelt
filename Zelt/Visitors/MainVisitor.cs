using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Zelt.Grammar;
using Zelt.CompilerHelpers;
using Antlr4.Runtime.Tree;

namespace Zelt.Visitors
{
    public partial class Visitor : ZeltParserBaseVisitor<object>
    {

        public Dictionary<string, ZType> Types { get; private set; } = new Dictionary<string, ZType>()
        {
            { "Int", new ZType("Int", true) },
            { "Float", new ZType("Float", true) },
            { "String", new ZType("String", true) },
            { "Bool", new ZType("Bool", true) },
        };

        public Dictionary<string, ZVariable> Variables { get; private set; } = new Dictionary<string, ZVariable>();
        public Dictionary<string, ZFunction> Functions { get; private set; } = new Dictionary<string, ZFunction>();
        public Dictionary<string, ZStruct> Structs { get; private set; } = new Dictionary<string, ZStruct>();
        public Dictionary<string, ZStructInstance> StructInstances { get; private set; } = new Dictionary<string, ZStructInstance>();



        public override object VisitDeclarationStatement([NotNull] ZeltParser.DeclarationStatementContext context)
        {
            // Get the variables declared
            List<ZVariable> variables = VisitDeclaration(context.declaration());

            // Add the variables to the dictionary
            foreach (var variable in variables)
            {
                if (Variables.ContainsKey(variable.name))
                {
                    // Variable already exists
                    ThrowError($"Variable '{variable.name}' was already declared.", context.Start.Line, context.Start.Column);
                }

                Variables.Add(variable.name, variable);
            }

            
            return base.VisitDeclarationStatement(context);
        }

        private new List<ZVariable> VisitDeclaration(ZeltParser.DeclarationContext declaration)
        {
            if (declaration.identifierList().ChildCount != declaration.typeList().ChildCount)
            {
                ThrowError(
                    $"Uneven number of names and types\nNames: {declaration.identifierList().ToInfoString}\nTypes: {declaration.typeList().ToInfoString}",
                    declaration.Start.Line,
                    declaration.Start.Column
                );
            }

            List<ZVariable> variables = new List<ZVariable>();

            List<string> names = GetIdentifiers(declaration.identifierList());
            List<ZType> types = GetTypes(declaration.typeList());

            for (int i = 0; i < names.Count; i++)
            {
                var variable = new ZVariable();
                variable.name = names[i];
                variable.type = types[i];
                variable.Line = declaration.Start.Line;
                variable.Column = declaration.Start.Column; // TODO: make this more accurate (get the column of the identifier)
                variables.Add(variable);
            }

            return variables;
        }

        private List<string> GetIdentifiers(ZeltParser.IdentifierListContext identifierList)
        {
            List<string> identifiers = new List<string>();

            foreach (var identifier in identifierList.IDENTIFIER())
            {
                identifiers.Add(identifier.GetText());
            }

            return identifiers;
        }

        private List<ZType> GetTypes(ZeltParser.TypeListContext typeList)
        {
            List<ZType> types = new List<ZType>();

            foreach (var type in typeList.type())
            {
                types.Add(VisitType(type));
            }

            return types;
        }

        public new ZType VisitType(ZeltParser.TypeContext context)
        {
            if (Types.TryGetValue(context.IDENTIFIER().GetText(), out ZType type))
            {
                return type;
            }
            else
            {
                ZType newType = new ZType();
                newType.name = context.IDENTIFIER().GetText();
                newType.isDefined = false;
                newType.interfaces = new List<ZInterface>();
                Types.Add(context.IDENTIFIER().GetText(), type);
                return newType;
            }
        }




        private void ThrowError(string message, int line, int column)
        {
            string errorPrefix = $"Error :: Line = {line}, Position = {column}\n\n";
            Console.WriteLine(errorPrefix + message + "\n");
            System.Environment.Exit(1);
        }
    }
}
