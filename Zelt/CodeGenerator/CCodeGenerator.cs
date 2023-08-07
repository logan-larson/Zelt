using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;

namespace Zelt.CodeGenerator
{
    public class CCodeGenerator : ICodeGenerator
    {
        public StreamWriter Stream { get; set; }

        public CCodeGenerator(StreamWriter stream)
        {
            Stream = stream;
        }

        public void GenerateCodeForProgram(ZProgram ast)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForStatement(IZStatement statement)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForDeclarationStatement(ZDeclarationStatement statement)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForAssignmentStatement(ZAssignmentStatement statement)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForDeclaration(ZDeclaration declaration)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForAssignment(ZAssignment assignment)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForExpression(IZExpression expression)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeForIdentifier(ZIdentifierExpression identifier)
        {
            throw new NotImplementedException();
        }
    }
}
