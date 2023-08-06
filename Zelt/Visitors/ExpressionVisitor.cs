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
        public Dictionary<string, ZVariable> Variables { get; private set; }
        public string[] SourceCodeLines { get; private set; }

        public ExpressionVisitor(
            Dictionary<string, ZType> types, 
            Dictionary<string, ZVariable> variables,
            string[] sourceCodeLines
        )
        {
            Types = types;
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
        }

        public override IZExpression VisitExpression([NotNull] ZeltParser.ExpressionContext context)
        {
            if (context is ZeltParser.LiteralExpressionContext literalExpressionContext)
            {
                return VisitLiteral(literalExpressionContext.literal());
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
                return VisitIdentifierExpression(identifierExpressionContext);
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
                return VisitNotExpression(notExpressionContext);
            }
            else if (context is ZeltParser.MultExpressionContext multExpressionContext)
            {
                return VisitMultExpression(multExpressionContext);
            }
            else if (context is ZeltParser.AddExpressionContext addExpressionContext)
            {
                return VisitAddExpression(addExpressionContext);
            }
            else if (context is ZeltParser.RelationalExpressionContext relationalExpressionContext)
            {
                return VisitRelationalExpression(relationalExpressionContext);
            }
            else if (context is ZeltParser.LogicalExpressionContext logicalExpressionContext)
            {
                return VisitLogicalExpression(logicalExpressionContext);
            }
            else if (context is ZeltParser.UnderscoreExpressionContext underscoreExpressionContext)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        public override IZExpression VisitLiteral([NotNull] ZeltParser.LiteralContext context)
        {
            if (context.INTEGER() != null)
            {
                return new ZLiteralExpression(new ZValue(int.Parse(context.INTEGER().GetText()), Types["Int"]));
            }
            else if (context.FLOAT() != null)
            {
                return new ZLiteralExpression(new ZValue(float.Parse(context.FLOAT().GetText()), Types["Float"]));
            }
            else if (context.STRING() != null)
            {
                return new ZLiteralExpression(new ZValue(context.STRING().GetText(), Types["String"]));
            }
            else if (context.BOOL() != null)
            {
                return new ZLiteralExpression(new ZValue(bool.Parse(context.BOOL().GetText()), Types["Bool"]));
            }
            else if (context.NULL() != null)
            {
                return new ZLiteralExpression(new ZValue((object?)null, Types["Null"]));
            }

            throw new NotImplementedException();
        }

        public override IZExpression VisitIdentifierExpression([NotNull] ZeltParser.IdentifierExpressionContext context)
        {
            string identifier = context.IDENTIFIER().GetText();
            // Check if the variable exists
            if (!Variables.ContainsKey(identifier))
            {
                ErrorHandler.ThrowError($"Variable '{identifier}' is not declared", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Check if the variable is initialized
            if (!Variables[identifier].IsDefined)
            {
                ErrorHandler.ThrowError($"Variable '{identifier}' is not defined", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Return the variable as an expression
            return new ZIdentifierExpression(identifier, Variables[identifier].Type);
        }

        public override IZExpression VisitNotExpression([NotNull] ZeltParser.NotExpressionContext context)
        {
            // Return the negation of the expression
            IZExpression expression = VisitExpression(context.expression());

            // Check if the type implements the Not interface
            if (!expression.Type.Implements(ZInterface.Negatable))
            {
                ErrorHandler.ThrowError($"Type {expression.Type.Name} does not implement the Negatable interface", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            return new ZUnaryExpression(expression, new ZUnaryOperator(EZUnaryOperator.Negate, expression.Type));
        }

        public override IZExpression VisitMultExpression([NotNull] ZeltParser.MultExpressionContext context)
        {
            IZExpression left = VisitExpression(context.expression(0));
            IZExpression right = VisitExpression(context.expression(1));

            // Check if the types are equal
            if (left.Type != right.Type)
            {
                ErrorHandler.ThrowError($"Cannot multiply types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            if (context.multOp().MULTIPLY() != null)
            {
                if (!left.Type.Implements(ZInterface.Multiplicative))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Multiplicative interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Multiply, left.Type));
            }
            else if (context.multOp().DIVIDE() != null)
            {
                if (!left.Type.Implements(ZInterface.Divisive))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Divisive interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Divide, left.Type));
            }
            else if (context.multOp().MODULO() != null)
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

        public override IZExpression VisitAddExpression([NotNull] ZeltParser.AddExpressionContext context)
        {
            IZExpression left = VisitExpression(context.expression(0));
            IZExpression right = VisitExpression(context.expression(1));

            // Check if the types are equal
            if (left.Type != right.Type)
            {
                ErrorHandler.ThrowError($"Cannot add types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            if (context.addOp().PLUS() != null)
            {
                if (!left.Type.Implements(ZInterface.Additive))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Additive interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Add, left.Type));
            }
            else if (context.addOp().MINUS() != null)
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

        public override IZExpression VisitRelationalExpression([NotNull] ZeltParser.RelationalExpressionContext context)
        {
            IZExpression left = VisitExpression(context.expression(0));
            IZExpression right = VisitExpression(context.expression(1));

            // Check if the types are equal
            if (left.Type.CompareTo(right.Type) != 0)
            {
                ErrorHandler.ThrowError($"Cannot compare types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            if (context.relOp().LESS_THAN() != null)
            {
                if (!left.Type.Implements(ZInterface.Comparable))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.LessThan, left.Type));
            }
            else if (context.relOp().LESS_THAN_OR_EQUAL() != null)
            {
                if (!left.Type.Implements(ZInterface.Comparable))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.LessThanOrEqual, left.Type));
            }
            else if (context.relOp().GREATER_THAN() != null)
            {
                if (!left.Type.Implements(ZInterface.Comparable))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.GreaterThan, left.Type));
            }
            else if (context.relOp().GREATER_THAN_OR_EQUAL() != null)
            {
                if (!left.Type.Implements(ZInterface.Comparable))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Comparable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.GreaterThanOrEqual, left.Type));
            }
            else if (context.relOp().EQUALS() != null)
            {
                if (!left.Type.Implements(ZInterface.Equatable))
                {
                    ErrorHandler.ThrowError($"{left.Type.Name} and {right.Type.Name} do not implement the Equatable interface.", context.Start.Line, context.Start.Column, SourceCodeLines);
                }
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.Equal, left.Type));
            }
            else if (context.relOp().NOT_EQUALS() != null)
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

        public override IZExpression VisitLogicalExpression([NotNull] ZeltParser.LogicalExpressionContext context)
        {
            IZExpression left = VisitExpression(context.expression(0));
            IZExpression right = VisitExpression(context.expression(1));

            // Check if the types can perform boolean operations
            if (left.Type.CompareTo(ZType.Bool) != 0)
            {
                ErrorHandler.ThrowError($"Cannot perform boolean operation on type {left.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }
            if (right.Type.CompareTo(ZType.Bool) != 0)
            {
                ErrorHandler.ThrowError($"Cannot perform boolean operation on type {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            if (context.boolOp().AND() != null)
            {
                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.And, left.Type));
            }
            else if (context.boolOp().OR() != null)
            {
                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Or, left.Type));
            }
            else
            {
                throw new NotImplementedException();
            }
        }


    }
}
