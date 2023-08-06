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
    public class ExpressionVisitor : ZeltParserBaseVisitor<IZExpression>
    {
        public Dictionary<string, ZType> Types { get; private set; }
        public string[] SourceCodeLines { get; private set; }

        public ExpressionVisitor(Dictionary<string, ZType> types, string[] sourceCodeLines)
        {
            Types = types;
            SourceCodeLines = sourceCodeLines;
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

    }
}
