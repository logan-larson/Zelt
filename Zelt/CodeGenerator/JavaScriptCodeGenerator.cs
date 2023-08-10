using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;

namespace Zelt.CodeGenerator
{
    public class JavaScriptCodeGenerator : ICodeGenerator
    {
        public StreamWriter Stream { get; set; }

        public Dictionary<EZUnaryOperator, string> UnaryOperators = new Dictionary<EZUnaryOperator, string>()
        {
            {  EZUnaryOperator.Negate, "!" }
        };

        public Dictionary<EZBinaryOperator, string> BinaryOperators = new Dictionary<EZBinaryOperator, string>()
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

        public JavaScriptCodeGenerator(StreamWriter stream)
        {
            Stream = stream;
        }

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

        public void GenerateCodeForStatement(IZStatement statement)
        {
            // Determine the type of statement
            if (statement is ZDeclarationStatement declarationStatement)
            {
                GenerateCodeForDeclarationStatement(declarationStatement);
            }
            else if (statement is ZAssignmentStatement assignmentStatement)
            {
                GenerateCodeForAssignmentStatement(assignmentStatement);
            }
            else if (statement is ZIfStatement ifStatement)
            {
                GenerateCodeForIfStatement(ifStatement);
            }
            else if (statement is ZWhileStatement whileStatement)
            {
                GenerateCodeForWhileStatement(whileStatement);
            }
            else if (statement is ZEachStatement eachStatement)
            {
                GenerateCodeForEachStatement(eachStatement);
            }
            /*
            else if (statement is ZExpressionStatement)
            {
                GenerateCodeForExpressionStatement((ZExpressionStatement)statement, stream);
            }
            */
            else
            {
                throw new NotImplementedException();
            }
            
            Stream.WriteLine();
        }

        // ------------------------------ Statements ------------------------------

        public void GenerateCodeForDeclarationStatement(ZDeclarationStatement statement)
        {
            foreach (var declaration in statement.Declarations)
            {
                GenerateCodeForDeclaration(declaration);
                Stream.WriteLine(";");
            }
        }

        public void GenerateCodeForAssignmentStatement(ZAssignmentStatement statement)
        {
            foreach (var assignment in statement.Assignments)
            {
                GenerateCodeForAssignment(assignment);
                Stream.WriteLine(";");
            }
        }

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

        /*
        public void GenerateCodeForEachStatement(ZEachStatement statement)
        {
            // Assuming all lists have the same size, use the first list for the loop range
            ZListExpression? list = statement.ListsToIterate[0];
            //ZIdentifierExpression? id = statement.ListsToIterate[0] as ZIdentifierExpression;

            // Create an iteration variable for index
            string iterator = "_i";
            Stream.Write($"for(let {iterator} = 0; {iterator} < ");

            if (id != null)
            {
                Stream.Write(id.Name);
            }
            else if (list != null)
            {
                GenerateCodeForListExpression(list);
            }

            Stream.WriteLine($".length; {iterator}++) {{");

            // Declare the iteration variables and assign the respective value from each list
            for (int i = 0; i < statement.IteratingVariables.Count; i++)
            {
                ZVariable variable = statement.IteratingVariables[i];

                ZListExpression? l = statement.ListsToIterate[i] as ZListExpression;
                ZIdentifierExpression? idExpr = statement.ListsToIterate[i] as ZIdentifierExpression;

                if (idExpr != null)
                {
                    Stream.WriteLine($"let {variable.Name} = {idExpr.Name}[{iterator}];");
                }
                else if (l != null)
                {
                    Stream.Write($"let {variable.Name} = ");
                    GenerateCodeForListExpression(l);
                    Stream.WriteLine($"[{iterator}];");
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            // Generate code for the body of the each loop
            foreach (IZStatement stmt in statement.Body)
            {
                GenerateCodeForStatement(stmt);
            }

            Stream.WriteLine("}");
        }
        */

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

        // -------------------- Assignments and Declarations ----------------------

        public void GenerateCodeForDeclaration(ZDeclaration declaration)
        {
            Stream.Write($"let {declaration.Variable.Name}");
        }

        public void GenerateCodeForAssignment(ZAssignment assignment)
        {
            if (assignment.IsDeclaration)
            {
                GenerateCodeForDeclaration(new ZDeclaration(assignment.Variable));

                Stream.Write($" = ");

                GenerateCodeForExpression(assignment.Expression);
            }
            else
            {
                Stream.Write($"{assignment.Variable.Name} = ");

                GenerateCodeForExpression(assignment.Expression);
            }
        }

        // ------------------------------ Expressions ------------------------------

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
                default:
                    throw new NotImplementedException();
            }
        }

        public void GenerateCodeForIntegerExpression(ZLiteralExpression<int> integerExpression)
        {
            Stream.Write(integerExpression.Value.ToString());
        }

        public void GenerateCodeForFloatExpression(ZLiteralExpression<float> floatExpression)
        {
            Stream.Write(floatExpression.Value.ToString());
        }

        public void GenerateCodeForStringExpression(ZLiteralExpression<string> stringExpression)
        {
            Stream.Write(stringExpression.Value);
        }

        public void GenerateCodeForBoolExpression(ZLiteralExpression<bool> boolExpression)
        {
            Stream.Write(boolExpression.Value.ToString().ToLowerInvariant());
        }

        public void GenerateCodeForIdentifier(ZIdentifierExpression identifier)
        {
            Stream.Write(identifier.Name);
        }

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

        public void GenerateCodeForUnaryExpression(ZUnaryExpression expression)
        {
            Stream.Write(UnaryOperators[expression.Operator.Operator]);
            Stream.Write("(");
            GenerateCodeForExpression(expression.Expression);
            Stream.Write(")");
        }

        public void GenerateCodeForBinaryExpression(ZBinaryExpression expression)
        {
            Stream.Write("(");
            GenerateCodeForExpression(expression.Left);
            Stream.Write(BinaryOperators[expression.Operator.Operator]);
            GenerateCodeForExpression(expression.Right);
            Stream.Write(")");
        }

    }
}
