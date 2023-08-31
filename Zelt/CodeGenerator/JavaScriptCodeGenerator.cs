using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zelt.CodeGenerator
{
    /// <summary>
    /// Generates JavaScript code from the Zelt AST.
    /// </summary>
    public class JavaScriptCodeGenerator : ICodeGenerator
    {
        /// <inheritdoc />
        public StreamWriter Stream { get; set; }

        private Dictionary<EZUnaryOperator, string> _unaryOperators = new Dictionary<EZUnaryOperator, string>()
        {
            {  EZUnaryOperator.Negate, "!" }
        };

        private Dictionary<EZBinaryOperator, string> _binaryOperators = new Dictionary<EZBinaryOperator, string>()
        {
            { EZBinaryOperator.Multiply, "*" },
            { EZBinaryOperator.Divide, "/" },
            { EZBinaryOperator.Add, "+" },
            { EZBinaryOperator.Subtract, "-" },
            { EZBinaryOperator.Modulo, "%" },
            { EZBinaryOperator.Equal, "==" },
            { EZBinaryOperator.NotEqual, "!=" },
            { EZBinaryOperator.GreaterThan, ">" },
            { EZBinaryOperator.GreaterThanOrEqual, ">=" },
            { EZBinaryOperator.LessThan, "<" },
            { EZBinaryOperator.LessThanOrEqual, "<=" },
            { EZBinaryOperator.And, "&&" },
            { EZBinaryOperator.Or, "||" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptCodeGenerator"/> class.
        /// </summary>
        /// <param name="stream">The stream to write the code to.</param>
        public JavaScriptCodeGenerator(StreamWriter stream)
        {
            Stream = stream;
        }

        /// <inheritdoc />
        public void GenerateCodeForProgram(ZProgram program)
        {
            if (Stream is null)
            {
                ErrorHandler.ThrowError("JSStream is null, cannot generate JavaScript code.");
            }

            foreach (var statement in program.Statements)
            {
                GenerateCodeForStatement(statement);
            }
        }

        /// <inheritdoc />
        public void GenerateCodeForStatement(ZStatement statement)
        {
            GenerateCodeForExpression(statement.Expression);
            Stream.WriteLine(";");
        }

        /// <inheritdoc />
        public void GenerateCodeForExpression(IZExpression expression)
        {
            switch (expression)
            {
                case ZLiteralExpression<int> intExpression:
                    GenerateCodeForIntegerExpression(intExpression);
                    break;
                case ZLiteralExpression<float> floatExpression:
                    GenerateCodeForFloatExpression(floatExpression);
                    break;
                case ZLiteralExpression<string> stringExpression:
                    GenerateCodeForStringExpression(stringExpression);
                    break;
                case ZLiteralExpression<bool> boolExpression:
                    GenerateCodeForBoolExpression(boolExpression);
                    break;
                case ZIdentifierExpression identifierExpression:
                    GenerateCodeForIdentifier(identifierExpression);
                    break;
                case ZUnaryExpression unaryExpression:
                    GenerateCodeForUnaryExpression(unaryExpression);
                    break;
                case ZBinaryExpression binaryExpression:
                    GenerateCodeForBinaryExpression(binaryExpression);
                    break;
                case ZListExpression listExpression:
                    GenerateCodeForListExpression(listExpression);
                    break;
                case ZFunctionExpression functionExpression:
                    GenerateCodeForFunctionExpression(functionExpression);
                    break;
                case ZStructExpression structExpression:
                    GenerateCodeForStructExpression(structExpression);
                    break;
                case ZStructConstructorExpression structConstructorExpression:
                    GenerateCodeForStructConstructorExpression(structConstructorExpression);
                    break;
                case ZCallerExpression callerExpression:
                    GenerateCodeForCallerExpression(callerExpression);
                    break;
                case ZChainedExpression chainedExpression:
                    GenerateCodeForChainedExpression(chainedExpression);
                    break;
                case ZFunctionCallExpression functionCallExpression:
                    GenerateCodeForFunctionCallExpression(functionCallExpression);
                    break;
                case ZExpressionPlaceholder expressionPlaceholder:
                    GenerateCodeForExpressionPlaceholder(expressionPlaceholder);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public void GenerateCodeForIdentifier(ZIdentifierExpression identifier)
        {
            Stream.Write(identifier.Name);
        }
        /*
        public void GenerateCodeForIfStatement(ZIfStatement statement)
        {
            Stream.Write("if (");
            GenerateCodeForExpression(statement.Condition);
            Stream.WriteLine(") {");
            foreach (var stmt in statement.TrueBody)
            {
                GenerateCodeForStatement(stmt);
            }
            Stream.WriteLine("}");
            if (statement.FalseBody.Count > 0)
            {
                if (statement.FalseBody.Count == 1 && statement.FalseBody[0] is ZIfStatement)
                {
                    Stream.Write("else ");
                    GenerateCodeForStatement(statement.FalseBody[0]);
                }
                else
                {
                    Stream.WriteLine("else {");

                    foreach (var stmt in statement.FalseBody)
                    {
                        GenerateCodeForStatement(stmt);
                    }

                    Stream.WriteLine("}");
                }
            }
        }

        public void GenerateCodeForWhileStatement(ZWhileStatement statement)
        {
            Stream.Write("while (");
            GenerateCodeForExpression(statement.Condition);
            Stream.WriteLine(") {");
            foreach (var stmt in statement.Body)
            {
                GenerateCodeForStatement(stmt);
            }
            Stream.WriteLine("}");
        }

        public void GenerateCodeForEachStatement(ZEachStatement statement)
        {
            // Assuming all lists have the same size, use the first list for the loop range
            string iterator = "_i";

            Stream.Write($"for(let {iterator} = 0; {iterator} < ");
            GenerateCodeForExpression(statement.ListsToIterate[0]); // Writing the first list expression directly
            Stream.Write($".length; {iterator}++) {{\n");

            // Declare the iteration variables and assign the respective value from each list
            for (int i = 0; i < statement.IteratingVariables.Count; i++)
            {
                ZVariable variable = statement.IteratingVariables[i];

                Stream.Write($"  let {variable.Name} = ");
                GenerateCodeForExpression(statement.ListsToIterate[i]); // Writing the list expression directly
                Stream.WriteLine($"[{iterator}];");
            }

            // Generate code for the body of the each loop
            foreach (IZStatement stmt in statement.Body)
            {
                GenerateCodeForStatement(stmt); // Indentation inside this method if needed
            }

            Stream.WriteLine("}");
        }

        public void GenerateCodeForReturnStatement(ZReturnStatement statement)
        {
            Stream.Write("return [");
            foreach (var (expression, index) in statement.ReturnValues.Select((e, i) => (e, i)))
            {
                GenerateCodeForExpression(expression.Expression);

                if (index < statement.ReturnValues.Count - 1)
                    Stream.Write(", ");
            }
            Stream.WriteLine("];");
        }
        */


        #region Assignments and Declarations

        /// <inheritdoc />
        public void GenerateCodeForDeclaration(List<ZDeclaration> declarations, bool hasAssignment = true)
        {
            string declarationsString = string.Join(", ", declarations.Select(v => v.Variable.Name));
            Stream.Write($"let {(hasAssignment ? "[" : "")}{declarationsString}{(hasAssignment ? "]" : "")}");
        }

        /// <inheritdoc />
        public void GenerateCodeForAssignment(List<ZAssignment> assignments, bool isDeclaration)
        {

            if (isDeclaration)
            {
                GenerateCodeForDeclaration(assignments.Select(s => new ZDeclaration(s.Variable)).ToList());

                Stream.Write($" = [");
            }
            else
            {
                string identifiersString = string.Join(", ", assignments.Select(v => v.Variable.Name));
                Stream.Write($"[{identifiersString}] = [");
            }

            int j = 0;

            while (j < assignments.Count)
            {
                var assignment = assignments[j];

                if (assignment.Expression is ZFunctionCallExpression functionCallExpression)
                {
                    // If the assignment is a function call, only generate the function call expression once
                    // and spread the return expressions of the function call
                    Stream.Write("..."); // Need to spread the return expressions of the function call, they are returned as an array

                    GenerateCodeForExpression(assignment.Expression);
                    // Add assignments for each of the return types
                    foreach (var retType in functionCallExpression.ReturnTypes)
                    {
                        if (j >= assignments.Count)
                        {
                            ErrorHandler.ThrowError("Internal compiler error: j >= identifiers.Count");
                            break;
                        }

                        j += 1;
                    }
                }
                else
                {
                    GenerateCodeForExpression(assignment.Expression);
                }

                if (j < assignments.Count - 1)
                    Stream.Write(", ");

                j += 1;
            }

            Stream.Write("]");
        }

        #endregion

        #region Expressions

        /// <inheritdoc />
        public void GenerateCodeForIntegerExpression(ZLiteralExpression<int> integerExpression)
        {
            Stream.Write(integerExpression.Value.ToString());
        }

        /// <inheritdoc />
        public void GenerateCodeForFloatExpression(ZLiteralExpression<float> floatExpression)
        {
            Stream.Write(floatExpression.Value.ToString());
        }

        /// <inheritdoc />
        public void GenerateCodeForStringExpression(ZLiteralExpression<string> stringExpression)
        {
            Stream.Write(stringExpression.Value);
        }

        /// <inheritdoc />
        public void GenerateCodeForBoolExpression(ZLiteralExpression<bool> boolExpression)
        {
            Stream.Write(boolExpression.Value.ToString().ToLowerInvariant());
        }

        /// <inheritdoc />
        public void GenerateCodeForListExpression(ZListExpression listExpression)
        {
            Stream.Write("[");
            for (int i = 0; i < listExpression.Elements.Count(); i++)
            {
                GenerateCodeForExpression(listExpression.Elements[i]);
                if (i < listExpression.Elements.Count() - 1)
                {
                    Stream.Write(", ");
                }
            }
            Stream.Write("]");
        }

        /// <inheritdoc />
        public void GenerateCodeForFunctionExpression(ZFunctionExpression functionExpression)
        {
            // Add the function keyword and parameters
            Stream.Write("function(");

            if (functionExpression.Caller is not null)
            {
                Stream.Write("caller, ");
            }

            for (int i = 0; i < functionExpression.ParameterValues.Count; i++)
            {
                Stream.Write(functionExpression.ParameterValues[i].Name); // Assuming ParameterValue has a property called 'Name'

                if (i < functionExpression.ParameterValues.Count - 1)
                {
                    Stream.Write(", ");
                }
            }
            Stream.WriteLine(") {");

            // Add the function body
            foreach (ZStatement statement in functionExpression.Body)
            {
                // Assuming there is a method to generate code for each statement
                GenerateCodeForStatement(statement);
            }

            Stream.WriteLine("}");
        }

        /// <inheritdoc />
        public void GenerateCodeForStructExpression(ZStructExpression structExpression)
        {
            // Do the instantiation
            Stream.Write("function(");

            // Add declarations as parameters
            for (int i = 0; i < structExpression.Declarations.Count + structExpression.Assignments.Count; i++)
            {
                if (i < structExpression.Declarations.Count)
                {
                    Stream.Write(structExpression.Declarations[i].Variable.Name);
                }
                else
                {
                    Stream.Write(structExpression.Assignments[i - structExpression.Declarations.Count].Variable.Name);
                    Stream.Write(" = ");
                    GenerateCodeForExpression(structExpression.Assignments[i - structExpression.Declarations.Count].Expression);
                }

                if (i < structExpression.Declarations.Count + structExpression.Assignments.Count - 1)
                {
                    Stream.Write(", ");
                }
            }

            Stream.WriteLine(") {");

            foreach (var declaration in structExpression.Declarations)
            {
                Stream.WriteLine($"this.{declaration.Variable.Name} = {declaration.Variable.Name};");
            }

            foreach (var assignment in structExpression.Assignments)
            {
                Stream.WriteLine($"this.{assignment.Variable.Name} = {assignment.Variable.Name};");
            }

            Stream.Write("}");
        }

        /// <inheritdoc />
        public void GenerateCodeForStructConstructorExpression(ZStructConstructorExpression structConstructorExpression)
        {
            Stream.Write($"new {structConstructorExpression.Name}(");
            foreach (var (expr, index) in structConstructorExpression.Arguments.Select((e, i) => (e, i)))
            {
                GenerateCodeForExpression(expr);

                if (index < structConstructorExpression.Arguments.Count - 1)
                {
                    Stream.Write(", ");
                }
            }
            Stream.Write(")");
        }

        /// <inheritdoc />
        public void GenerateCodeForCallerExpression(ZCallerExpression callerExpression)
        {
            Stream.Write("caller");
        }

        /// <inheritdoc />
        public void GenerateCodeForUnaryExpression(ZUnaryExpression expression)
        {
            Stream.Write(_unaryOperators[expression.Operator.Operator]);
            Stream.Write("(");
            GenerateCodeForExpression(expression.Expression);
            Stream.Write(")");
        }

        /// <inheritdoc />
        public void GenerateCodeForBinaryExpression(ZBinaryExpression expression)
        {
            Stream.Write("(");

            GenerateCodeForExpression(expression.Left);
            Stream.Write(_binaryOperators[expression.Operator.Operator]);
            GenerateCodeForExpression(expression.Right);

            Stream.Write(")");
        }

        /// <inheritdoc />
        public void GenerateCodeForChainedExpression(ZChainedExpression expression)
        {
            if (expression.Expressions == null || expression.Expressions.Count == 0)
                throw new Exception("Invalid chained expression");

            // Visit the first expression
            GenerateCodeForExpression(expression.Expressions[0]);

            // Iterate through the rest of the expressions in the chain
            for (int i = 1; i < expression.Expressions.Count; i++)
            {
                // Assuming you want to chain with a dot operator
                Stream.Write(".");
                GenerateCodeForExpression(expression.Expressions[i]);
            }
        }

        /// <inheritdoc />
        public void GenerateCodeForFunctionCallExpression(ZFunctionCallExpression functionCall)
        {
            // Write the function name
            Stream.Write(functionCall.Name + "(");

            // Write the arguments, separated by commas
            for (int i = 0; i < functionCall.Arguments.Count; i++)
            {
                GenerateCodeForExpression(functionCall.Arguments[i]);
                if (i < functionCall.Arguments.Count - 1)
                {
                    Stream.Write(", ");
                }
            }

            // Close the function call
            Stream.Write(")");
        }

        /// <inheritdoc />
        public void GenerateCodeForExpressionPlaceholder(ZExpressionPlaceholder expressionPlaceholder)
        {
            //Stream.Write(expressionPlaceholder.Name);
        }

        #endregion
    }
}
