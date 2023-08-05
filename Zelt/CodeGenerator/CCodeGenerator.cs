﻿using System;
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

        public void GenerateCodeForAST(ZAST ast)
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

        public void GenerateCodeForDeclaration(ZDeclaration declaration)
        {
            throw new NotImplementedException();
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