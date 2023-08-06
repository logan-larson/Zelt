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
    public class AssignmentVisitor : ZeltParserBaseVisitor<List<ZAssignment>>
    {
        public Dictionary<string, ZType> Types { get; private set; }
        public Dictionary<string, ZVariable> Variables { get; private set; }
        public string[] SourceCodeLines { get; private set; }

        public AssignmentVisitor(Dictionary<string, ZType> types, Dictionary<string, ZVariable> variables, string[] sourceCodeLines)
        {
            Types = types;
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
        }

        public override List<ZAssignment> VisitAssignment([NotNull] ZeltParser.AssignmentContext context)
        {
            // Assignment syntax: identifierList ':' typeList '=' expressionList

            // Get the identifiers
            List<string> identifiers = new List<string>();
            foreach (var identifier in context.identifierList().IDENTIFIER())
            {
                identifiers.Add(identifier.GetText());
            }

            // Check if the identifiers are already declared
            foreach (var identifier in identifiers)
            {
                if (Variables.ContainsKey(identifier))
                {
                    ErrorHandler.ThrowError($"Variable '{identifier}' is already declared", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
            }

            // Get the types
            List<ZType> types = new List<ZType>();
            foreach (var type in context.typeList().type())
            {
                types.Add(new TypeVisitor(Types).VisitType(type));
            }

            // Check if the number of identifiers and types match
            if (identifiers.Count != types.Count)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> typesStrings = types.Select(t => t.Name).ToList();
                string typesString = string.Join(", ", typesStrings);

                ErrorHandler.ThrowError($"Uneven number of names and types\nNames: [{identifiersString}]\nTypes: [{typesString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Get the expressions
            List<IZExpression> expressions = new List<IZExpression>();
            foreach (var expression in context.expressionList().expression())
            {
                expressions.Add(new ExpressionVisitor(Types, SourceCodeLines).VisitExpression(expression));
            }

            // Check if the number of identifiers and expressions match
            if (identifiers.Count != expressions.Count)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> expressionsStrings = expressions.Select(e => e.Type.Name).ToList();
                string expressionsString = string.Join(", ", expressionsStrings);

                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: [{identifiersString}]\nExpression Types: [{expressionsString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Create the assignments
            List<ZAssignment> assignments = new List<ZAssignment>();
            for (int i = 0; i < identifiers.Count; i++)
            {
                var variable = new ZVariable(identifiers[i], types[i], true);
                assignments.Add(new ZAssignment(variable, expressions[i], true));
            }

            return assignments;
        }

        public override List<ZAssignment> VisitInferAssignment([NotNull] ZeltParser.InferAssignmentContext context)
        {
            // Infer assignment syntax: identifierList ':=' expressionList

            // Get the identifiers
            List<string> identifiers = new List<string>();
            foreach (var identifier in context.identifierList().IDENTIFIER())
            {
                identifiers.Add(identifier.GetText());
            }

            // Check if the identifiers are already declared
            foreach (var identifier in identifiers)
            {
                if (Variables.ContainsKey(identifier))
                {
                    ErrorHandler.ThrowError($"Variable '{identifier}' is already declared", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
            }

            // Get the expressions
            List<IZExpression> expressions = new List<IZExpression>();
            foreach (var expression in context.expressionList().expression())
            {
                expressions.Add(new ExpressionVisitor(Types, SourceCodeLines).VisitExpression(expression));
            }

            // Check if the number of identifiers and expressions match
            if (identifiers.Count != expressions.Count)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> expressionsStrings = expressions.Select(e => e.Type.Name).ToList();
                string expressionsString = string.Join(", ", expressionsStrings);

                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: [{identifiersString}]\nExpression Types: [{expressionsString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Create the assignments
            List<ZAssignment> assignments = new List<ZAssignment>();
            for (int i = 0; i < identifiers.Count; i++)
            {
                var variable = new ZVariable(identifiers[i], expressions[i].Type, true);
                assignments.Add(new ZAssignment(variable, expressions[i], true));
            }

            return assignments;
        }

        public override List<ZAssignment> VisitSimpleAssignment([NotNull] ZeltParser.SimpleAssignmentContext context)
        {
            // Simple assignment syntax: identifierList '=' expressionList

            // Get the identifiers
            List<string> identifiers = new List<string>();
            foreach (var identifier in context.identifierList().IDENTIFIER())
            {
                identifiers.Add(identifier.GetText());
            }

            // Check if the identifiers exist
            foreach (var identifier in identifiers)
            {
                if (!Variables.ContainsKey(identifier))
                {
                    ErrorHandler.ThrowError($"Variable '{identifier}' does not exist", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
            }

            // Get the expressions
            List<IZExpression> expressions = new List<IZExpression>();
            foreach (var expression in context.expressionList().expression())
            {
                expressions.Add(new ExpressionVisitor(Types, SourceCodeLines).VisitExpression(expression));
            }

            // Check if the number of identifiers and expressions match
            if (identifiers.Count != expressions.Count)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> expressionsStrings = expressions.Select(e => e.Type.Name).ToList();
                string expressionsString = string.Join(", ", expressionsStrings);

                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: [{identifiersString}]\nExpression Types: [{expressionsString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Check if the identifier types match the expression types
            for (int i = 0; i < identifiers.Count; i++)
            {
                if (Variables[identifiers[i]].Type != expressions[i].Type)
                {
                    ErrorHandler.ThrowError($"Type mismatch\nVariable '{identifiers[i]}' is of type '{Variables[identifiers[i]].Type.Name}'\nExpression is of type '{expressions[i].Type.Name}'", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
            }

            // Create the assignments
            List<ZAssignment> assignments = new List<ZAssignment>();
            for (int i = 0; i < identifiers.Count; i++)
            {
                var variable = Variables[identifiers[i]];
                variable.IsDefined = true;
                assignments.Add(new ZAssignment(variable, expressions[i], false));
            }

            return assignments;
        }
    }
}
