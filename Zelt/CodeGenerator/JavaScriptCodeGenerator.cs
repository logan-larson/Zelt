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

        public void GenerateCodeForAST(ZAST ast)
        {
            foreach (var statement in ast.Statements)
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
            else if (statement is ZAssignmentStatement)
            {
                GenerateCodeForAssignmentStatement((ZAssignmentStatement)statement);
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
        }

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

        public void GenerateCodeForDeclaration(ZDeclaration declaration)
        {
            Stream.Write($"let {declaration.Variable.Name}");
        }

        public void GenerateCodeForAssignment(ZAssignment assignment)
        {
            if (assignment.IsDeclaration)
            {
                GenerateCodeForDeclaration(new ZDeclaration(assignment.Variable));
                //Stream.Write($"let {assignment.Variable.Name} = ");
                Stream.Write($" = ");
                GenerateCodeForExpression(assignment.Expression);
            }
            else
            {
                //GenerateCodeForIdentifier(new ZIdentifierExpression(assignment.Variable.Name, assignment.Variable.Type));
                Stream.Write($"{assignment.Variable.Name} = ");
                GenerateCodeForExpression(assignment.Expression);
            }
        }

        public void GenerateCodeForExpression(IZExpression expression)
        {
            if (expression is ZLiteralExpression literal)
            {
                GenerateCodeForLiteral(literal);
            }
            else if (expression is ZIdentifierExpression identifier)
            {
                // Not supported by parser yet, add identifier visitor??
                GenerateCodeForIdentifier(identifier);
            }
            else if (expression is ZUnaryExpression unaryExpression)
            {
                GenerateCodeForUnaryExpression(unaryExpression);
            }
            else if (expression is ZBinaryExpression binaryExpression)
            {
                GenerateCodeForBinaryExpression(binaryExpression);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void GenerateCodeForLiteral(ZLiteralExpression literal)
        {
            GenerateCodeForValue(literal.Value);
        }

        public void GenerateCodeForValue(ZValue value)
        {
            if (value.IntValue != null)
            {
                Stream.Write(value.IntValue.ToString());
            }
            else if (value.FloatValue != null)
            {
                Stream.Write(value.FloatValue.ToString());
            }
            else if (value.StringValue != null)
            {
                Stream.Write(value.StringValue);
            }
            else if (value.BoolValue != null)
            {
                Stream.Write(value.BoolValue.ToString()?.ToLowerInvariant());
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void GenerateCodeForIdentifier(ZIdentifierExpression identifier)
        {
            Stream.Write(identifier.Name);
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
