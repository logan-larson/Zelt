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
        public ZType? CallerType { get; private set; }

        public AssignmentVisitor(Dictionary<string, ZType> types, Dictionary<string, ZVariable> variables, string[] sourceCodeLines, ZType? callerType = null)
        {
            Types = types;
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
            CallerType = callerType;
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

            // Get the expressions
            List<IZExpression> expressions = new List<IZExpression>();
            int expressionCount = 0;
            foreach (var expression in context.expressionList().expression())
            {
                var expr = new ExpressionVisitor(Types, Variables, SourceCodeLines, CallerType).VisitExpression(expression);

                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();
                        expressionCount += functionCallExpression.ReturnTypes.Count;
                    }
                    else
                    {
                        expressionCount += 1;
                    }
                }
                else
                {
                        // TODO: Determine when this gets hit
                    expressionCount += 1;
                }

                expressions.Add(expr);
            }

            // Check if the number of identifiers and expressions match
            // The expressions count needs to include the number of return types for each of the functions in the expression list
            // I think it does

            if (identifiers.Count != expressionCount)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> expressionsStrings = expressions.Select(e => e.Type.Name).ToList();
                string expressionsString = string.Join(", ", expressionsStrings);

                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: [{identifiersString}]\nExpression Types: [{expressionsString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Check if the types and expression types match
            // Construct a list of expression types including the types from the function call's return types
            List<ZType> expressionTypes = new List<ZType>();

            foreach (var expr in expressions)
            {
                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();
                        expressionTypes.AddRange(functionCallExpression.ReturnTypes);
                    }
                    else
                    {
                        expressionTypes.Add(expr.Type);
                    }
                }
                else
                {
                    expressionTypes.Add(expr.Type);
                }
            }

            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].CompareTo(expressionTypes[i]) != 0)
                {
                    ErrorHandler.ThrowError($"Type '{expressionTypes[i].Name}' cannot be assigned to type '{types[i].Name}'", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
            }

            // Create the assignments
            List<ZAssignment> assignments = new List<ZAssignment>();

            int j = 0;
            while (j < identifiers.Count)
            {
                var expr = expressions[j];
                    
                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();

                        // Add assignments for each of the return types
                        foreach (var retType in functionCallExpression.ReturnTypes)
                        {
                            if (j >= identifiers.Count)
                            {
                                ErrorHandler.ThrowError("Internal compiler error: j >= identifiers.Count", context.Start.Line, context.Start.Column, SourceCodeLines);
                                break;
                            }

                            var variable = new ZVariable(identifiers[j], retType, true);

                            variable.Line = context.Start.Line;
                            variable.Column = context.Start.Column;

                            assignments.Add(new ZAssignment(variable, functionCallExpression, true));

                            j += 1;
                        }
                    }
                    else
                    {
                        var variable = new ZVariable(identifiers[j], expr.Type, true);

                        variable.Line = context.Start.Line;
                        variable.Column = context.Start.Column;

                        assignments.Add(new ZAssignment(variable, expr, true));
                    }
                }
                else
                {
                    var variable = new ZVariable(identifiers[j], expr.Type, true);

                    variable.Line = context.Start.Line;
                    variable.Column = context.Start.Column;

                    assignments.Add(new ZAssignment(variable, expr, true));
                }

                j += 1;
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
            int expressionCount = 0;
            foreach (var expression in context.expressionList().expression())
            {
                var expr = new ExpressionVisitor(Types, Variables, SourceCodeLines, CallerType).VisitExpression(expression);

                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();
                        expressionCount += functionCallExpression.ReturnTypes.Count;
                    }
                    else
                    {
                        // TODO: Determine when this gets hit
                        expressionCount += 1;
                    }
                }
                else
                {
                    expressionCount += 1;
                }

                expressions.Add(expr);
            }

            // Check if the number of identifiers and expressions match
            if (identifiers.Count != expressionCount)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> expressionsStrings = expressions.Select(e => e.Type.Name).ToList();
                string expressionsString = string.Join(", ", expressionsStrings);

                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: [{identifiersString}]\nExpression Types: [{expressionsString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Since it is type inference, we can't check if the types match

            // Create the assignments
            List<ZAssignment> assignments = new List<ZAssignment>();

            int j = 0;
            while (j < identifiers.Count)
            {
                var expr = expressions[j];
                    
                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();

                        // Add assignments for each of the return types
                        foreach (var retType in functionCallExpression.ReturnTypes)
                        {
                            if (j >= identifiers.Count)
                            {
                                ErrorHandler.ThrowError("Internal compiler error: j >= identifiers.Count", context.Start.Line, context.Start.Column, SourceCodeLines);
                                break;
                            }

                            var variable = new ZVariable(identifiers[j], retType, true);

                            variable.Line = context.Start.Line;
                            variable.Column = context.Start.Column;

                            assignments.Add(new ZAssignment(variable, functionCallExpression, true));

                            j += 1;
                        }
                    }
                    else
                    {
                        var variable = new ZVariable(identifiers[j], expr.Type, true);

                        variable.Line = context.Start.Line;
                        variable.Column = context.Start.Column;

                        assignments.Add(new ZAssignment(variable, expr, true));
                    }
                }
                else
                {
                    var variable = new ZVariable(identifiers[j], expr.Type, true);

                    variable.Line = context.Start.Line;
                    variable.Column = context.Start.Column;

                    assignments.Add(new ZAssignment(variable, expr, true));
                }

                j += 1;
            }

            return assignments;
        }

        public override List<ZAssignment> VisitSimpleAssignment([NotNull] ZeltParser.SimpleAssignmentContext context)
        {
            // Simple assignment syntax: identifierList '=' expressionList

            // The identifiers list can now contain chained identifiers, representing accessing a field of a struct


            // Get the identifiers
            List<string> identifiers = new List<string>();
            foreach (var identifier in context.identifierList().IDENTIFIER())
            {
                identifiers.Add(identifier.GetText());
            }

            List<ZVariable> variables = new List<ZVariable>();

            // Check if the identifiers exist
            foreach (var identifier in identifiers)
            {
                var variable = Variables[identifier];
                if (variable is null)
                {
                    ErrorHandler.ThrowError($"Variable '{identifier}' does not exist", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                else
                {
                    variables.Add(variable);
                }
            }

            // Get the expressions
            List<IZExpression> expressions = new List<IZExpression>();
            int expressionCount = 0;
            foreach (var expression in context.expressionList().expression())
            {
                var expr = new ExpressionVisitor(Types, Variables, SourceCodeLines, CallerType).VisitExpression(expression);

                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();
                        expressionCount += functionCallExpression.ReturnTypes.Count;
                    }
                    else
                    {
                        // TODO: Determine when this gets hit
                        expressionCount += 1;
                    }
                }
                else
                {
                    expressionCount += 1;
                }

                expressions.Add(expr);
            }

            // Check if the number of identifiers and expressions match
            if (identifiers.Count != expressionCount)
            {
                string identifiersString = string.Join(", ", identifiers);
                List<string> expressionsStrings = expressions.Select(e => e.Type.Name).ToList();
                string expressionsString = string.Join(", ", expressionsStrings);

                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: [{identifiersString}]\nExpression Types: [{expressionsString}]", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Check if the types and expression types match
            // Construct a list of expression types including the types from the function call's return types
            List<ZType> expressionTypes = new List<ZType>();

            foreach (var expr in expressions)
            {
                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();
                        expressionTypes.AddRange(functionCallExpression.ReturnTypes);
                    }
                    else
                    {
                        expressionTypes.Add(expr.Type);
                    }
                }
                else
                {
                    expressionTypes.Add(expr.Type);
                }
            }

            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].Type.CompareTo(expressionTypes[i]) != 0)
                {
                    ErrorHandler.ThrowError($"Type '{expressionTypes[i].Name}' cannot be assigned to type '{variables[i].Type.Name}'", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
            }

            // Create the assignments
            List<ZAssignment> assignments = new List<ZAssignment>();

            int j = 0;
            while (j < identifiers.Count)
            {
                var expr = expressions[j];
                    
                if (expr is ZChainedExpression chainedExpression)
                {
                    if (chainedExpression.Expressions.Last().Type.CompareTo(ZType.FunctionCall) == 0)
                    {
                        ZFunctionCallExpression functionCallExpression = (ZFunctionCallExpression) chainedExpression.Expressions.Last();

                        // Add assignments for each of the return types
                        foreach (var retType in functionCallExpression.ReturnTypes)
                        {
                            if (j >= identifiers.Count)
                            {
                                ErrorHandler.ThrowError("Internal compiler error: j >= identifiers.Count", context.Start.Line, context.Start.Column, SourceCodeLines);
                                break;
                            }

                            var variable = new ZVariable(identifiers[j], retType, true);

                            variable.Line = context.Start.Line;
                            variable.Column = context.Start.Column;

                            assignments.Add(new ZAssignment(variable, functionCallExpression, false));

                            j += 1;
                        }
                    }
                    else
                    {
                        var variable = new ZVariable(identifiers[j], expr.Type, true);

                        variable.Line = context.Start.Line;
                        variable.Column = context.Start.Column;

                        assignments.Add(new ZAssignment(variable, expr, false));
                    }
                }
                else
                {
                    var variable = new ZVariable(identifiers[j], expr.Type, true);

                    variable.Line = context.Start.Line;
                    variable.Column = context.Start.Column;

                    assignments.Add(new ZAssignment(variable, expr, false));
                }

                j += 1;
            }


            return assignments;
        }
    }
}
