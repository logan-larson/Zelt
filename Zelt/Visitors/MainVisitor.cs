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
            List<ZDeclaration> declarations = VisitDeclaration(context.declaration());

            Root.Statements.Add(new ZDeclarationStatement(declarations));

            return new ZDeclarationStatement(declarations);
        }

        // Visit each type of assignment

        public override ZAssignmentStatement VisitAssignmentStatement([NotNull] ZeltParser.AssignmentStatementContext context)
        {
            List<ZAssignment> assignments = new List<ZAssignment>();

            if (context.assignment() != null)
            {
                assignments = VisitAssignment(context.assignment());

                Root.Statements.Add(new ZAssignmentStatement(assignments));

                return new ZAssignmentStatement(assignments);
            }
            else if (context.inferAssignment() != null)
            {
                throw new NotImplementedException();
                //return new ZAssignmentStatement(VisitInferAssignment(context.inferAssignment()));
            }
            else if (context.simpleAssignment() != null)
            {
                throw new NotImplementedException();
                //return new ZAssignmentStatement(VisitSimpleAssignment(context.simpleAssignment()));
            }

            throw new NotImplementedException();
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

            // Get the types
            List<ZType> types = new List<ZType>();
            foreach (var type in context.typeList().type())
            {
                types.Add(VisitType(type));
            }

            // Check if the number of identifiers and types match
            if (identifiers.Count != types.Count)
            {
                ErrorHandler.ThrowError($"Uneven number of names and types\nNames: {context.identifierList().ToInfoString}\nTypes: {context.typeList().ToInfoString}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Get the expressions
            List<IZExpression> expressions = new List<IZExpression>();
            foreach (var expression in context.expressionList().expression())
            {
                expressions.Add(VisitExpression(expression));
            }

            // Check if the number of identifiers and expressions match
            if (identifiers.Count != expressions.Count)
            {
                ErrorHandler.ThrowError($"Uneven number of names and expressions\nNames: {context.identifierList().ToInfoString}\nExpressions: {context.expressionList().ToInfoString}", context.Start.Line, context.Start.Column, SourceCodeLines);
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

        public override IZExpression VisitExpression([NotNull] ZeltParser.ExpressionContext context)
        {
            if (context is ZeltParser.LiteralExpressionContext literalExpressionContext)
            {
                return new LiteralVisitor(Types, SourceCodeLines).VisitLiteral(literalExpressionContext.literal());
            }
            else if (context is ZeltParser.ListExpressionContext listExpressionContext)
            {
                //return new LiteralVisitor(Types).VisitList(listExpressionContext.list());
                throw new NotImplementedException();
            }
            else if (context is ZeltParser.AccessorExpressionContext accessorExpressionContext)
            {
                //return new AccessorVisitor(Types, Variables).VisitAccessor(accessorExpressionContext.accessor());
                throw new NotImplementedException();
            }
            else if (context is ZeltParser.IdentifierExpressionContext identifierExpressionContext)
            {
                //return new IdentifierVisitor(Types, Variables).VisitIdentifier(identifierExpressionContext.identifier());
                throw new NotImplementedException();
            }
            else if (context is ZeltParser.FunctionCallExpressionContext functionCallExpressionContext)
            {
                //return new FunctionCallVisitor(Types, Variables, Functions).VisitFunctionCall(functionCallExpressionContext.functionCall());
                throw new NotImplementedException();
            }
            else if (context is ZeltParser.ParenExpressionContext parenExpressionContext)
            {
                return VisitExpression(parenExpressionContext.expression());
            }
            else if (context is ZeltParser.NotExpressionContext notExpressionContext)
            {
                // Return the negation of the expression
                IZExpression expression = VisitExpression(notExpressionContext.expression());

                // Check if the type implements the Not interface
                if (!expression.Type.Implements(ZInterface.Negatable))
                {
                    ErrorHandler.ThrowError($"Type {expression.Type.Name} does not implement the Negatable interface", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                return new ZUnaryExpression(expression, new ZUnaryOperator(EZUnaryOperator.Negate, expression.Type));
            }
            else if (context is ZeltParser.MultExpressionContext multExpressionContext)
            {
                IZExpression left = VisitExpression(multExpressionContext.expression(0));
                IZExpression right = VisitExpression(multExpressionContext.expression(1));

                // Check if the types are equal
                if (left.Type != right.Type)
                {
                    ErrorHandler.ThrowError($"Cannot multiply types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (multExpressionContext.multOp().MULTIPLY() != null)
                {
                    if (!left.Type.Implements(ZInterface.Multiplicative))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Multiplicative interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.Multiply, left.Type));
                }
                else if (multExpressionContext.multOp().DIVIDE() != null)
                {
                    if (!left.Type.Implements(ZInterface.Divisive))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Divisive interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.Divide, left.Type));
                }
                else if (multExpressionContext.multOp().MODULO() != null)
                {
                    if (!left.Type.Implements(ZInterface.Modulable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Modulable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.Modulo, left.Type));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else if (context is ZeltParser.AddExpressionContext addExpressionContext)
            {
                IZExpression left = VisitExpression(addExpressionContext.expression(0));
                IZExpression right = VisitExpression(addExpressionContext.expression(1));

                // Check if the types are equal
                if (left.Type != right.Type)
                {
                    ErrorHandler.ThrowError($"Cannot add types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (addExpressionContext.addOp().PLUS() != null)
                {
                    if (!left.Type.Implements(ZInterface.Additive))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Additive interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.Add, left.Type));
                }
                else if (addExpressionContext.addOp().MINUS() != null)
                {
                    if (!left.Type.Implements(ZInterface.Subtractive))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Subtractive interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.Subtract, left.Type));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else if (context is ZeltParser.RelationalExpressionContext relationalExpressionContext)
            {
                IZExpression left = VisitExpression(relationalExpressionContext.expression(0));
                IZExpression right = VisitExpression(relationalExpressionContext.expression(1));

                // Check if the types are equal
                if (left.Type.CompareTo(right.Type) != 0)
                {
                    ErrorHandler.ThrowError($"Cannot compare types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (relationalExpressionContext.relOp().LESS_THAN() != null)
                {
                    if (!left.Type.Implements(ZInterface.Comparable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.LessThan, left.Type));
                }
                else if (relationalExpressionContext.relOp().LESS_THAN_OR_EQUAL() != null)
                {
                    if (!left.Type.Implements(ZInterface.Comparable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.LessThanOrEqual, left.Type));
                }
                else if (relationalExpressionContext.relOp().GREATER_THAN() != null)
                {
                    if (!left.Type.Implements(ZInterface.Comparable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.GreaterThan, left.Type));
                }
                else if (relationalExpressionContext.relOp().GREATER_THAN_OR_EQUAL() != null)
                {
                    if (!left.Type.Implements(ZInterface.Comparable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.GreaterThanOrEqual, left.Type));
                }
                else if (relationalExpressionContext.relOp().EQUALS() != null)
                {
                    if (!left.Type.Implements(ZInterface.Equatable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Equatable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.Equal, left.Type));
                }
                else if (relationalExpressionContext.relOp().NOT_EQUALS() != null)
                {
                    if (!left.Type.Implements(ZInterface.Equatable))
                    {
                        ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Equatable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }
                    return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.NotEqual, left.Type));
                }
                else
                {
                    throw new NotImplementedException();
                }

            }
            else if (context is ZeltParser.BoolOpExpressionContext boolOpExpressionContext)
            {
                IZExpression left = VisitExpression(boolOpExpressionContext.expression(0));
                IZExpression right = VisitExpression(boolOpExpressionContext.expression(1));

                // Check if the types can perform boolean operations
                if (left.Type.CompareTo(ZType.Bool) != 0)
                {
                    ErrorHandler.ThrowError($"Cannot perform boolean operation on type {left.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                if (right.Type.CompareTo(ZType.Bool) != 0)
                {
                    ErrorHandler.ThrowError($"Cannot perform boolean operation on type {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (boolOpExpressionContext.boolOp().AND() != null)
                {
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.And, left.Type));
                }
                else if (boolOpExpressionContext.boolOp().OR() != null)
                {
                    return new ZBinaryExpression(left, right,
                        new ZBinaryOperator(EZBinaryOperator.Or, left.Type));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else if (context is ZeltParser.UnderscoreExpressionContext underscoreExpressionContext)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
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
                types.Add(VisitType(type));
            }

            // Check if the number of identifiers and types match
            if (identifiers.Count != types.Count)
            {
                ErrorHandler.ThrowError($"Uneven number of names and types\nNames: {context.identifierList().ToInfoString}\nTypes: {context.typeList().ToInfoString}", context.Start.Line, context.Start.Column, SourceCodeLines);
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


        public override ZType VisitType([NotNull] ZeltParser.TypeContext context)
        {
            // If the type is already defined, return it
            if (Types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
            {
                return type;
            }
            
            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null, null);

            Types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }
    }
}
