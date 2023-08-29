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
            if (context.primaryExpression() is not null)
            {
                List<IZExpression> expressions = new List<IZExpression>
                {
                    // Add the primary expression to the list of expressions
                    VisitPrimaryExpression(context.primaryExpression())
                };

                // For each expression in the expressionTail, add it to the list of expressions
                for (int i = 0; i < context.expressionTail().Length; i++)
                {
                    expressions.Add(VisitExpressionTail(context.expressionTail()[i]));
                }

                // Return new chained expression
                return new ZChainedExpression(expressions, expressions.Last().Type);
            }
            else if (context.logicalExpression() is not null)
            {
                return VisitLogicalExpression(context.logicalExpression());
            }

            throw new NotImplementedException();
        }

        public override IZExpression VisitPrimaryExpression([NotNull] ZeltParser.PrimaryExpressionContext context)
        {
            
            // These are the primary expressions that have lexer tokens in them so they need to be handled separately
            if (context is ZeltParser.IdentifierExpressionContext idExprContext)
            {
                return VisitIdentifierExpression(idExprContext);
            }

            if (context is ZeltParser.CallerExpressionContext callerExprContext)
            {
                return VisitCallerExpression(callerExprContext);
            }

            if (context is ZeltParser.ParenExpressionContext parenExprContext)
            {
                return VisitParenExpression(parenExprContext);
            }

            // Otherwise just visit the expression
            return base.VisitPrimaryExpression(context);
        }

        public override IZExpression VisitExpressionTail([NotNull] ZeltParser.ExpressionTailContext context)
        {
            /*
            if (context.functionIdentifier() is not null)
            {
                return VisitFunctionIdentifier(context.functionIdentifier());
            }
            */

            if (context.IDENTIFIER() is not null)
            {
                // Find the variable
                // The problem with this is the variable could be in a different scope so we need to find the scope
                // TODO: Find the scope
                if (!Variables.ContainsKey(context.IDENTIFIER().GetText()))
                    ErrorHandler.ThrowError($"Variable {context.IDENTIFIER().GetText()} does not exist", context.Start.Line, context.Start.Column, SourceCodeLines);

                // Return the variable
                return new ZIdentifierExpression(context.IDENTIFIER().GetText(), Variables[context.IDENTIFIER().GetText()].Type);
            }

            return base.VisitExpressionTail(context);
        }

        // --------------------------------------------------------------------------------------------
        // ---------------------------------- Primary Expressions -------------------------------------
        // --------------------------------------------------------------------------------------------

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

        public override IZExpression VisitList([NotNull] ZeltParser.ListContext context)
        {
            List<IZExpression> listElements = new List<IZExpression>();
            ZType? elementType = null;

            foreach (var elementContext in context.listElement())
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

        /*
        public override IZExpression VisitFunction([NotNull] ZeltParser.FunctionContext context)
        {
            Dictionary<string, ZVariable> variables = new Dictionary<string, ZVariable>(Variables);
            // Get parameter values
            List<ZParameterValue> parameterValues = new List<ZParameterValue>();

            if (context.parameterDeclarationList() is not null) // If there are parameters
            {
                foreach (var parameter in context.parameterDeclarationList().parameterDeclaration())
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
            }

            // Get return types
            List<ZType> returnTypes = new List<ZType>();
            foreach (var returnType in context.typeList().type())
            {
                returnTypes.Add(new TypeVisitor(Types, SourceCodeLines).Visit(returnType));
            }

            // If caller exists, add it to the function
            ZType? caller = null;
            if (context.type() != null)
            {
                caller = new TypeVisitor(Types, SourceCodeLines).Visit(context.type());
            }

            // Get the function body
            List<IZStatement> body = new List<IZStatement>();

            // If there is a body, visit it
            if (context.block() != null)
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

                foreach (var statement in context.block().statement())
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
        */

        /*
        public override IZExpression VisitFunctionCallNoCaller([NotNull] ZeltParser.FunctionCallNoCallerContext context)
        {
            // Make sure the function being called exists as a variable in the current scope
            // Get the function variable
            string functionIdentifier = context.functionIdentifier().IDENTIFIER().GetText();
            ZVariable functionVariable = Variables[functionIdentifier];

            if (functionVariable == null)
            {
                ErrorHandler.ThrowError($"The function '{functionIdentifier}' does not exist", context.Start.Line, context.Start.Column, SourceCodeLines);
                return new ZNullExpression();
            }

            // Get the function's parameter types
            List<ZType> parameterTypes = new List<ZType>();
            List<ZType> returnTypes = new List<ZType>();

            if (functionVariable.Type is ZFunctionType functionType)
            {
                parameterTypes = functionType.ParameterTypes;
                returnTypes = functionType.ReturnTypes;

                // Make sure this function does not have a caller
                if (functionType.CallerType is not null)
                {
                    ErrorHandler.ThrowError($"The function '{functionIdentifier}' requires a caller, but you have not provided one", context.Start.Line, context.Start.Column, SourceCodeLines);
                    return new ZNullExpression();
                }
            }
            else
            {
                ErrorHandler.ThrowError($"The variable '{functionIdentifier}' is not a function", context.Start.Line, context.Start.Column, SourceCodeLines);
                return new ZNullExpression();
            }

            // Make sure the number of parameters passed in matches the number of parameters the function takes
            List<IZExpression> argumentsList = new List<IZExpression>();

            if (context.expressionList() is not null)
            {

                if (context.expressionList().expression().Length != parameterTypes.Count)
                {
                    ErrorHandler.ThrowError($"The number of parameters passed in does not match the number of parameters the function takes", context.Start.Line, context.Start.Column, SourceCodeLines);
                    return new ZNullExpression();
                }

                // Make sure the parameters passed in match the function's parameter types
                for (int i = 0; i < context.expressionList().expression().Length; i++)
                {
                    IZExpression expression = Visit(context.expressionList().expression()[i]);

                    if (expression.Type.CompareTo(parameterTypes[i]) != 0)
                    {
                        ErrorHandler.ThrowError($"The parameter type does not match the function's parameter type", context.Start.Line, context.Start.Column, SourceCodeLines);
                        return new ZNullExpression();
                    }

                    argumentsList.Add(expression);
                }
            }

            return new ZFunctionCallExpression(functionVariable.Name, argumentsList, returnTypes, ZType.FunctionCall);
        }
        */

        /*
        public override IZExpression VisitStruct([NotNull] ZeltParser.StructContext context)
        {
            List<ZDeclaration> structDeclarations = new List<ZDeclaration>();
            List<ZAssignment> structAssignments = new List<ZAssignment>();

            // Visit the struct block to get the struct variables
            if (context.structBlock() is not null)
            {
                // Setup the scope for the struct
                Dictionary<string, ZVariable> structScope = new Dictionary<string, ZVariable>(Variables);

                // Visit each declaration statement
                foreach (var declaration in context.structBlock().declarationStatement())
                {
                    List<ZDeclaration> declarations = new DeclarationVisitor(Types, structScope, SourceCodeLines).VisitDeclaration(declaration.declaration());

                    structDeclarations.AddRange(declarations);
                }

                // Visit each infer assignment statement
                foreach (var inferAssignment in context.structBlock().inferAssignment())
                {
                    List<ZAssignment> assignments = new AssignmentVisitor(Types, structScope, SourceCodeLines).VisitInferAssignment(inferAssignment);

                    structAssignments.AddRange(assignments);
                }

                // Visit each assignment statement
                foreach (var assignment in context.structBlock().assignment())
                {
                    List<ZAssignment> assignments = new AssignmentVisitor(Types, structScope, SourceCodeLines).VisitAssignment(assignment);

                    structAssignments.AddRange(assignments);
                }
            }

            // Create the struct type
            List<ZVariable> structVariables = structDeclarations.Select(d => d.Variable).ToList();
            structVariables.AddRange(structAssignments.Select(a => a.Variable));

            ZStructType structType = new ZStructType(structVariables.Select(v => v.Type).ToList());

            // Create the struct expression
            return new ZStructExpression(structDeclarations, structAssignments, structType);
        }
        */

        public override IZExpression VisitStructConstructor([NotNull] ZeltParser.StructConstructorContext context)
        {
            // Get the struct type
            string structIdentifier = context.IDENTIFIER().GetText();
            ZVariable structVariable = Variables[structIdentifier];

            if (structVariable is null)
            {
                ErrorHandler.ThrowError($"The struct '{structIdentifier}' does not exist", context.Start.Line, context.Start.Column, SourceCodeLines);
                return new ZNullExpression();
            }

            if (structVariable.Type is not ZStructType structType)
            {
                ErrorHandler.ThrowError($"The variable '{structIdentifier}' is not a struct", context.Start.Line, context.Start.Column, SourceCodeLines);
                return new ZNullExpression();
            }

            // Make sure the number of parameters passed in matches the number of parameters the struct takes
            List<IZExpression> argumentsList = new List<IZExpression>();

            if (context.expressionList() is not null)
            {
                if (context.expressionList().expression().Length != structType.MemberTypes.Count)
                {
                    ErrorHandler.ThrowError($"The number of parameters passed in does not match the number of parameters the struct takes", context.Start.Line, context.Start.Column, SourceCodeLines);
                    return new ZNullExpression();
                }

                // Make sure the parameters passed in match the struct's member types
                for (int i = 0; i < context.expressionList().expression().Length; i++)
                {
                    IZExpression expression = Visit(context.expressionList().expression()[i]);

                    if (expression.Type.CompareTo(structType.MemberTypes[i]) != 0)
                    {
                        ErrorHandler.ThrowError($"The parameter type does not match the struct's member type", context.Start.Line, context.Start.Column, SourceCodeLines);
                        return new ZNullExpression();
                    }

                    argumentsList.Add(expression);
                }
            }

            return new ZStructConstructorExpression(structVariable.Name, argumentsList, structType);
        }

        // --------------------------------------------------------------------------------------------
        // ---------------------------- Primary Expressions No Production -----------------------------
        // --------------------------------------------------------------------------------------------

        public override IZExpression VisitCallerExpression([NotNull] ZeltParser.CallerExpressionContext context)
        {
                if (CallerType is null)
                    ErrorHandler.ThrowError("Cannot use caller expression outside of a caller function", context.Start.Line, context.Start.Column, SourceCodeLines);

                return new ZCallerExpression(CallerType ?? ZType.Null);
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

        // IDK if these need to be implemented
        // VisitParenExpression
        public override IZExpression VisitParenExpression([NotNull] ZeltParser.ParenExpressionContext context)
        {
            return VisitExpression(context.expression());
        }


        // --------------------------------------------------------------------------------------------
        // ---------------------------------- Precedence Expressions ----------------------------------
        // --------------------------------------------------------------------------------------------

        public override IZExpression VisitUnaryExpression([NotNull] ZeltParser.UnaryExpressionContext context)
        {
            // If the expression is the primary expression, return it
            if (context.primaryExpression() is not null)
            {
                return VisitPrimaryExpression(context.primaryExpression());
            }

            // Otherwise get the expression and operator and return the unary expression

            // Get the expression
            IZExpression expression = VisitExpression(context.expression());

            // Get the operator
            string op = context.NOT().GetText();

            if (op is null)
            {
                ErrorHandler.ThrowError("Unary operator is null, I don't know how you achieved this.", context.Start.Line, context.Start.Column, SourceCodeLines);
            }

            // Check if the type implements the Not interface
            TypeChecker.TypeImplements(expression.Type, ZInterface.Negatable, context.Start.Line, context.Start.Column, SourceCodeLines);

            // Check if the type implements the Negatable interface
            //if (!expression.Type.Implements(ZInterface.Negatable))
            //{
                //ErrorHandler.ThrowError($"Type '{expression.Type}' does not implement the Negatable interface", context.Start.Line, context.Start.Column, SourceCodeLines);
            //}

            return new ZUnaryExpression(expression, new ZUnaryOperator(EZUnaryOperator.Negate, expression.Type));
        }

        public override IZExpression VisitMultExpression([NotNull] ZeltParser.MultExpressionContext context)
        {
            List<IZExpression> expressions = new List<IZExpression>();
            List<ZBinaryOperator> ops = new List<ZBinaryOperator>();

            IZExpression current = VisitUnaryExpression(context.unaryExpression(0));

            expressions.Add(current);

            for (int i = 0; i < context.multOp().Length; i++)
            {
                IZExpression next = VisitUnaryExpression(context.unaryExpression(i + 1));

                // Get the corresponding multiplicative operator
                string op = context.multOp(i).GetText();

                // TODO: Set this up so that I don't have to do these long switch statement checks
                //List<ZInterface> interfaces = new List<ZInterface>() { ZInterface.Multiplicative, ZInterface.Divisive, ZInterface.Modulable };
                //TypeChecker.TypeImplementsAny(current.Type, interfaces, context.Start.Line, context.Start.Column, SourceCodeLines);
                //TypeChecker.TypeImplementsAny(next.Type, interfaces, context.Start.Line, context.Start.Column, SourceCodeLines);

                // Check if the types can perform multiplication operations
                if (!current.Type.Implements(ZInterface.Multiplicative) && !current.Type.Implements(ZInterface.Divisive) && !current.Type.Implements(ZInterface.Modulable))
                {
                    switch (op)
                    {
                        case "*":
                            ErrorHandler.ThrowError($"Cannot perform multiplication operation on type {current.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                            break;
                        case "/":
                            ErrorHandler.ThrowError($"Cannot perform division operation on type {current.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                            break;
                        case "%":
                            ErrorHandler.ThrowError($"Cannot perform modulation operation on type {current.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                            break;

                    }
                }

                if (!next.Type.Implements(ZInterface.Multiplicative) && !next.Type.Implements(ZInterface.Divisive) && !next.Type.Implements(ZInterface.Modulable))
                {
                    switch (op)
                    {
                        case "*":
                            ErrorHandler.ThrowError($"Cannot perform multiplication operation on type {next.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                            break;
                        case "/":
                            ErrorHandler.ThrowError($"Cannot perform division operation on type {next.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                            break;
                        case "%":
                            ErrorHandler.ThrowError($"Cannot perform modulation operation on type {next.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                            break;

                    }
                }

                expressions.Add(next);

                // Combine the results based on the operator
                switch (op) {
                    case "*":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Multiply, expressions[0].Type));
                        break;
                    case "/":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Divide, expressions[0].Type));
                        break;
                    case "%":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Modulo, expressions[0].Type));
                        break;
                    default:
                        ErrorHandler.ThrowError($"'{op}' is not a valid multiplication, division, or modulation operator", context.Start.Line, context.Start.Column, SourceCodeLines);
                        break;
                }
            }

            if (expressions.Count == 1 && ops.Count == 0)
            {
                return current;
            }

            return new ZBinaryExpression(expressions, ops);
        }

        public override IZExpression VisitAddExpression([NotNull] ZeltParser.AddExpressionContext context)
        {
            List<IZExpression> expressions = new List<IZExpression>();
            List<ZBinaryOperator> ops = new List<ZBinaryOperator>();

            IZExpression current = VisitMultExpression(context.multExpression(0));

            expressions.Add(current);

            for (int i = 0; i < context.addOp().Length; i++)
            {
                IZExpression next = VisitMultExpression(context.multExpression(i + 1));

                // Get the corresponding additive operator
                string op = context.addOp(i).GetText();

                // Check if the types can perform add operations
                if (!current.Type.Implements(ZInterface.Additive) && !current.Type.Implements(ZInterface.Subtractive))
                {
                    ErrorHandler.ThrowError($"Cannot perform {(op == "+" ? "addition ": "subraction")} operation on type {current.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (!next.Type.Implements(ZInterface.Additive) && !next.Type.Implements(ZInterface.Subtractive))
                {
                    ErrorHandler.ThrowError($"Cannot perform {(op == "+" ? "addition ": "subraction")} operation on type {next.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                expressions.Add(next);

                // Combine the results based on the operator
                switch (op) {
                    case "+":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Add, expressions[0].Type));
                        break;
                    case "-":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Subtract, expressions[0].Type));
                        break;
                    default:
                        ErrorHandler.ThrowError($"'{op}' is not a valid addition or subtraction operator", context.Start.Line, context.Start.Column, SourceCodeLines);
                        break;
                }
            }

            if (expressions.Count == 1 && ops.Count == 0)
            {
                return current;
            }

            return new ZBinaryExpression(expressions, ops);
        }

        public override IZExpression VisitRelationalExpression([NotNull] ZeltParser.RelationalExpressionContext context)
        {
            List<IZExpression> expressions = new List<IZExpression>();
            List<ZBinaryOperator> ops = new List<ZBinaryOperator>();

            IZExpression current = VisitAddExpression(context.addExpression(0));

            expressions.Add(current);

            for (int i = 0; i < context.relOp().Length; i++)
            {
                IZExpression next = VisitAddExpression(context.addExpression(i + 1));

                // Check if the types can perform relational operations
                if (!current.Type.Implements(ZInterface.Comparable) && !current.Type.Implements(ZInterface.Equatable))
                {
                    ErrorHandler.ThrowError($"Cannot perform relational operation on type {current.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (!next.Type.Implements(ZInterface.Comparable) && !next.Type.Implements(ZInterface.Equatable))
                {
                    ErrorHandler.ThrowError($"Cannot perform relational operation on type {next.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                expressions.Add(next);

                // Get the corresponding relational operator
                string op = context.relOp(i).GetText();

                // Combine the results based on the operator
                switch (op) {
                    case "<":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.LessThan, ZType.Bool));
                        break;
                    case "<=":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.LessThanOrEqual, ZType.Bool));
                        break;
                    case ">":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.GreaterThan, ZType.Bool));
                        break;
                    case ">=":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.GreaterThanOrEqual, ZType.Bool));
                        break;
                    case "==":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Equal, ZType.Bool));
                        break;
                    case "!=":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.NotEqual, ZType.Bool));
                        break;
                    default:
                        ErrorHandler.ThrowError($"'{op}' is not a valid relational operator", context.Start.Line, context.Start.Column, SourceCodeLines);
                        break;
                }
            }

            if (expressions.Count == 1 && ops.Count == 0)
            {
                return current;
            }

            return new ZBinaryExpression(expressions, ops);
        }

        public override IZExpression VisitLogicalExpression([NotNull] ZeltParser.LogicalExpressionContext context)
        {
            List<IZExpression> expressions = new List<IZExpression>();
            List<ZBinaryOperator> ops = new List<ZBinaryOperator>();

            IZExpression current = VisitRelationalExpression(context.relationalExpression(0));

            expressions.Add(current);

            for (int i = 0; i < context.boolOp().Length; i++)
            {
                IZExpression next = VisitRelationalExpression(context.relationalExpression(i + 1));

                // Check if the types can perform boolean operations
                if (!current.Type.Implements(ZInterface.Logical))
                {
                    ErrorHandler.ThrowError($"Cannot perform boolean operation on type {current.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                if (!next.Type.Implements(ZInterface.Logical))
                {
                    ErrorHandler.ThrowError($"Cannot perform boolean operation on type {next.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
                }

                expressions.Add(next);

                // Get the corresponding boolean operator
                string op = context.boolOp(i).GetText();

                // Combine the results based on the operator
                switch (op) {
                    case "&&":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.And, ZType.Bool));
                        break;
                    case "||":
                        ops.Add(new ZBinaryOperator(EZBinaryOperator.Or, ZType.Bool));
                        break;
                    default:
                        ErrorHandler.ThrowError($"'{op}' is not a valid boolean operator", context.Start.Line, context.Start.Column, SourceCodeLines);
                        break;
                }
            }

            if (expressions.Count == 1 && ops.Count == 0)
            {
                return current;
            }

            return new ZBinaryExpression(expressions, ops);
        }
    }
}
