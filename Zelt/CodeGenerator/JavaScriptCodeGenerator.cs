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
            /*
            else if (statement is ZAssignmentStatement)
            {
                GenerateCodeForAssignmentStatement((ZAssignmentStatement)statement, stream);
            }
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
            }
        }

        public void GenerateCodeForDeclaration(ZDeclaration declaration)
        {
            Stream.WriteLine($"let {declaration.Variable.Name};");
        }

        public void GenerateCodeForAssignment(ZVariable variable, ZExpression expression)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForExpression(ZExpression expression)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForLiteral(ZLiteralExpression literal)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForIdentifier(ZIdentifierExpression identifier)
        {
            throw new NotImplementedException();
        }
    }
}
