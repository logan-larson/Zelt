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
    public class DeclarationVisitor : ZeltParserBaseVisitor<List<ZDeclaration>>
    {
        public Dictionary<string, ZType> Types { get; private set; }
        public Dictionary<string, ZVariable> Variables { get; private set; }
        public string[] SourceCodeLines { get; private set; }

        public DeclarationVisitor(Dictionary<string, ZType> types, Dictionary<string, ZVariable> variables, string[] sourceCodeLines)
        {
            Types = types;
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
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
                    ErrorHandler.ThrowError($"Variable '{identifier}' was already declared.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

            }

            // Get the types
            List<ZType> types = new List<ZType>();
            foreach (var type in context.typeList().type())
            {
                types.Add(new TypeVisitor(Types, SourceCodeLines).VisitType(type));
            }

            // Check if the number of identifiers and types match
            if (identifiers.Count != types.Count)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> typesStrings = types.Select(t => t.Name).ToList();
                string typesString = string.Join(", ", typesStrings);
                ErrorHandler.ThrowError($"Uneven number of names and types\nNames: [{identifiersString}]\nTypes: [{typesString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            List<ZDeclaration> declarations = new List<ZDeclaration>();

            // Create the variables
            for (int i = 0; i < identifiers.Count; i++)
            {
                // All variables when declared are set to null, TODO: change to default value of type later
                // If I do this, that means every struct declaration will have to provide a default value for the struct
                var variable = new ZVariable(identifiers[i], types[i]);

                Variables.Add(variable.Name, variable);

                declarations.Add(new ZDeclaration(variable));
            }

            return declarations;
        }
    }
}
