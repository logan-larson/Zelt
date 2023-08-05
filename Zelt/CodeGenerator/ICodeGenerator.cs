using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;

namespace Zelt.CodeGenerator
{
    public interface ICodeGenerator
    {
        StreamWriter Stream { get; set; }

        /*
        void ICodeGenerator(StreamWriter stream)
        {
            Stream = stream;
        }
        */

        void GenerateCodeForAST(ZAST ast);

        void GenerateCodeForStatement(IZStatement statement);

        void GenerateCodeForDeclarationStatement(ZDeclarationStatement statement);

        void GenerateCodeForDeclaration(ZDeclaration declaration);

        void GenerateCodeForAssignment(ZVariable variable, ZExpression expression);

        void GenerateCodeForExpression(ZExpression expression);

        void GenerateCodeForLiteral(ZLiteralExpression literal);

        void GenerateCodeForIdentifier(ZIdentifierExpression identifier);

        /*
        void GenerateCodeForList(ZListExpression list);

        void GenerateCodeForFunctionDeclaration(ZFunctionDecalaration functionDecalaration);

        void GenerateCodeForFunction(ZFunctionExpression function);

        void GenerateCodeForStructDeclaration(ZStructDeclaration structDeclaration);

        void GenerateCodeForStructInstance(ZStructInstance structInstance);
        */
    }
}
