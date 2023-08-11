using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        public ZType? CallerType { get; set; } = null;

        public ExpressionVisitor(
            Dictionary<string, ZType> types, 
            Dictionary<string, ZVariable> variables,
            string[] sourceCodeLines,
            ZType? callerType = null
        )
        {
            Types = types;
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
            CallerType = callerType;
        }

        public override IZExpression VisitExpression([NotNull] ZeltParser.ExpressionContext context)
        {
            if (context is ZeltParser.LiteralExpressionContext literalExpressionContext)
            {
                return VisitLiteral(literalExpressionContext.literal());
            }
            else if (context is ZeltParser.ListExpressionContext listExpressionContext)
            {
                return VisitListExpression(listExpressionContext);
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
            else if (context is ZeltParser.FunctionExpressionContext functionExpressionContext)
            {
                return VisitFunctionExpression(functionExpressionContext);
            }
            else if (context is ZeltParser.FunctionCallExpressionContext functionCallExpressionContext)
            {
                return VisitFunctionCallExpression(functionCallExpressionContext);
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
            else if (context is ZeltParser.CallerExpressionContext callerExpressionContext)
            {
                if (CallerType == null)
                    ErrorHandler.ThrowError("Cannot use caller expression outside of a function", callerExpressionContext.Start.Line, callerExpressionContext.Start.Column, SourceCodeLines);

                return new ZCallerExpression(CallerType ?? ZType.Null);
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
                return new ZIntegerExpression(int.Parse(context.INTEGER().GetText()));
            }
            else if (context.FLOAT() != null)
            {
                return new ZFloatExpression(float.Parse(context.FLOAT().GetText()));
            }
            else if (context.STRING() != null)
            {
                return new ZStringExpression(context.STRING().GetText());
            }
            else if (context.BOOL() != null)
            {
                return new ZBoolExpression(bool.Parse(context.BOOL().GetText()));
            }
            else if (context.NULL() != null)
            {
                return new ZNullExpression();
            }

            throw new NotImplementedException();
        }

        public override IZExpression VisitListExpression([NotNull] ZeltParser.ListExpressionContext context)
        {
            List<IZExpression> listElements = new List<IZExpression>();
            ZType? elementType = null;

            foreach (var elementContext in context.list().listElement())
            {
                if (elementContext.DOUBLE_PERIOD() != null)
                {
                    var startExpr = Visit(elementContext.expression(0));
                    var endExpr = Visit(elementContext.expression(1));

                    if (startExpr.Type.CompareTo(ZType.Int) != 0 || endExpr.Type.CompareTo(ZType.Int) != 0)
                    {
                        ErrorHandler.ThrowError("Range expressions must be integers", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }

                    var start = (ZIntegerExpression)startExpr;
                    var end = (ZIntegerExpression)endExpr;

                    if (elementType == null)
                    {
                        elementType = startExpr.Type;
                    }

                    if (startExpr.Type.CompareTo(elementType) != 0 || endExpr.Type.CompareTo(elementType) != 0)
                    {
                        ErrorHandler.ThrowError("All elements in a list must be of the same type", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }

                    if (start.Value < end.Value)
                    {
                        for (var i = start.Value; i <= end.Value; i++)
                        {
                            listElements.Add(new ZIntegerExpression(i));
                        }
                    }
                    else
                    {
                        for (var i = start.Value; i >= end.Value; i--)
                        {
                            listElements.Add(new ZIntegerExpression(i));
                        }
                    }
                }
                else
                {
                    var expr = Visit(elementContext.expression(0));

                    if (elementType == null)
                    {
                        elementType = expr.Type;
                    }

                    if (expr.Type.CompareTo(elementType) != 0)
                    {
                        ErrorHandler.ThrowError("All elements in a list must be of the same type", context.Start.Line, context.Start.Column, SourceCodeLines);
                    }

                    listElements.Add(expr);
                }
            }

            return new ZListExpression(listElements, elementType ?? ZType.Null);
        }

        public override IZExpression VisitFunctionExpression([NotNull] ZeltParser.FunctionExpressionContext context)
        {
            Dictionary<string, ZVariable> variables = new Dictionary<string, ZVariable>(Variables);
            // Get parameter values
            List<ZParameterValue> parameterValues = new List<ZParameterValue>();
            foreach (var parameter in context.function().parameterDeclarationList().parameterDeclaration())
            {
                if (parameter.declaration() is not null)
                {
                    List<ZDeclaration> declarations = new DeclarationVisitor(Types, variables, SourceCodeLines).VisitDeclaration(parameter.declaration());
                    foreach (var (declaration, position) in declarations.Select((d, i) => (d, i)))
                    {
                        parameterValues.Add(new ZParameterValue(declaration.Variable.Name, declaration.Variable.Type, null, position));
                    }
                }
                else if (parameter.assignment() is not null)
                {
                    List<ZAssignment> assignments = new AssignmentVisitor(Types, variables, SourceCodeLines, CallerType).VisitAssignment(parameter.assignment());
                    foreach (var (assignment, position) in assignments.Select((a, i) => (a, i)))
                    {
                        parameterValues.Add(new ZParameterValue(assignment.Variable.Name, assignment.Variable.Type, assignment.Expression, position));
                    }
                }
                else if (parameter.inferAssignment() is not null)
                {
                    List<ZAssignment> assignments = new AssignmentVisitor(Types, variables, SourceCodeLines, CallerType).VisitInferAssignment(parameter.inferAssignment());
                    foreach (var (assignment, position) in assignments.Select((a, i) => (a, i)))
                    {
                        parameterValues.Add(new ZParameterValue(assignment.Variable.Name, assignment.Variable.Type, assignment.Expression, position));
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            // Get return types
            List<ZType> returnTypes = new List<ZType>();
            foreach (var returnType in context.function().typeList().type())
            {
                returnTypes.Add(new TypeVisitor(Types, SourceCodeLines).Visit(returnType));
            }

            // If caller exists, add it to the function
            ZType? caller = null;
            if (context.function().type() != null)
            {
                caller = new TypeVisitor(Types, SourceCodeLines).Visit(context.function().type());
            }

            // Get the function body
            List<IZStatement> body = new List<IZStatement>();

            // If there is a body, visit it
            if (context.function().block() != null)
            {
                // Setup the scope for the body
                Dictionary<string, ZVariable> bodyVariables = new Dictionary<string, ZVariable>(Variables);

                // Add the parameters to the body scope
                foreach (var parameter in parameterValues)
                {
                    bodyVariables.Add(parameter.Name, new ZVariable(parameter.Name, parameter.Type, true));
                }

                if (caller is not null)
                    bodyVariables.Add("caller", new ZVariable("caller", caller, true));

                StatementVisitor visitor = new StatementVisitor(Types, bodyVariables, SourceCodeLines, caller);

                foreach (var statement in context.function().block().statement())
                {
                    // If the statement is a return statement, check if it is valid
                     IZStatement zStatement = visitor.Visit(statement);

                    if (zStatement is ZReturnStatement returnStatement)
                    {
                        // Check that the length of the return statement matches the length of the return types
                        if (returnStatement.ReturnValues.Count != returnTypes.Count)
                        {
                            ErrorHandler.ThrowError("The number of return values does not match the number of return types", context.Start.Line, context.Start.Column, SourceCodeLines);
                        }

                        // Check if the return types of the expressions match the return types of the function
                        foreach (var (returnValue, returnType) in returnStatement.ReturnValues.Zip(returnTypes))
                        {
                            if (returnValue.Type.CompareTo(returnType) != 0)
                            {
                                ErrorHandler.ThrowError("The return type does not match the return type of the function", context.Start.Line, context.Start.Column, SourceCodeLines);
                            }
                        }
                    }

                    body.Add(zStatement);
                }

                // Type check the body -- is this necessary?
                TypeChecker.CheckVariableDeclarationTypes(bodyVariables, SourceCodeLines);
            }

            // Create a new function
            ZFunctionType functionType = new ZFunctionType(parameterValues.Select(p => p.Type).ToList(), returnTypes);

            return new ZFunctionExpression(parameterValues, returnTypes, body, caller, functionType);
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
            TypeChecker.TypeImplements(expression.Type, ZInterface.Negatable, context.Start.Line, context.Start.Column, SourceCodeLines);

            return new ZUnaryExpression(expression, new ZUnaryOperator(EZUnaryOperator.Negate, expression.Type));
        }

        public override IZExpression VisitMultExpression([NotNull] ZeltParser.MultExpressionContext context)
        {
            IZExpression left = VisitExpression(context.expression(0));
            IZExpression right = VisitExpression(context.expression(1));

            // Check if the types are equal
            if (left.Type.CompareTo(right.Type) != 0)
            {
                ErrorHandler.ThrowError($"Cannot multiply types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            if (context.multOp().MULTIPLY() != null)
            {
                TypeChecker.TypeImplements(left.Type, ZInterface.Multiplicative, context.Start.Line, context.Start.Column, SourceCodeLines);
                TypeChecker.TypeImplements(right.Type, ZInterface.Multiplicative, context.Start.Line, context.Start.Column, SourceCodeLines);

                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Multiply, left.Type));
            }
            else if (context.multOp().DIVIDE() != null)
            {
                TypeChecker.TypeImplements(left.Type, ZInterface.Divisive, context.Start.Line, context.Start.Column, SourceCodeLines);
                TypeChecker.TypeImplements(right.Type, ZInterface.Divisive, context.Start.Line, context.Start.Column, SourceCodeLines);

                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Divide, left.Type));
            }
            else if (context.multOp().MODULO() != null)
            {
                TypeChecker.TypeImplements(left.Type, ZInterface.Modulable, context.Start.Line, context.Start.Column, SourceCodeLines);
                TypeChecker.TypeImplements(right.Type, ZInterface.Modulable, context.Start.Line, context.Start.Column, SourceCodeLines);

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
            if (left.Type.CompareTo(right.Type) != 0)
            {
                ErrorHandler.ThrowError($"Cannot add types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            if (context.addOp().PLUS() != null)
            {
                TypeChecker.TypeImplements(left.Type, ZInterface.Additive, context.Start.Line, context.Start.Column, SourceCodeLines);
                TypeChecker.TypeImplements(right.Type, ZInterface.Additive, context.Start.Line, context.Start.Column, SourceCodeLines);

                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Add, left.Type));
            }
            else if (context.addOp().MINUS() != null)
            {
                TypeChecker.TypeImplements(left.Type, ZInterface.Subtractive, context.Start.Line, context.Start.Column, SourceCodeLines);
                TypeChecker.TypeImplements(right.Type, ZInterface.Subtractive, context.Start.Line, context.Start.Column, SourceCodeLines);

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
            
            // Check if the type implements the Comparable interface
            TypeChecker.TypeImplements(left.Type, ZInterface.Comparable, context.Start.Line, context.Start.Column, SourceCodeLines);
            TypeChecker.TypeImplements(right.Type, ZInterface.Comparable, context.Start.Line, context.Start.Column, SourceCodeLines);

            if (context.relOp().LESS_THAN() != null)
            {
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.LessThan, ZType.Bool));
            }
            else if (context.relOp().LESS_THAN_OR_EQUAL() != null)
            {
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.LessThanOrEqual, ZType.Bool));
            }
            else if (context.relOp().GREATER_THAN() != null)
            {
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.GreaterThan, ZType.Bool));
            }
            else if (context.relOp().GREATER_THAN_OR_EQUAL() != null)
            {
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.GreaterThanOrEqual, ZType.Bool));
            }
            else if (context.relOp().EQUALS() != null)
            {
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.Equal, ZType.Bool));
            }
            else if (context.relOp().NOT_EQUALS() != null)
            {
                return new ZBinaryExpression(left, right, new ZBinaryOperator(EZBinaryOperator.NotEqual, ZType.Bool));
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
                    new ZBinaryOperator(EZBinaryOperator.And, ZType.Bool));
            }
            else if (context.boolOp().OR() != null)
            {
                return new ZBinaryExpression(left, right,
                    new ZBinaryOperator(EZBinaryOperator.Or, ZType.Bool));
            }
            else
            {
                throw new NotImplementedException();
            }
        }


    }
}
