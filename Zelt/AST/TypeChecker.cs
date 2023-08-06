using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public class TypeChecker
    {
        public Dictionary<string, ZVariable> Variables { get; set; }

        public string[] SourceCodeLines { get; set; }

        public TypeChecker(Dictionary<string, ZVariable> variables, string[] sourceCodeLines)
        {
            Variables = variables;
            SourceCodeLines = sourceCodeLines;
        }

        public void CheckVariableDeclarationTypes()
        {
            foreach (var variable in Variables)
            {
                if (!variable.Value.Type.IsDefined)
                {
                    ErrorHandler.ThrowError($"Variable '{variable.Value.Name}' type '{variable.Value.Type.Name}' was not defined.", variable.Value.Line, variable.Value.Column, SourceCodeLines);
                }
            }
        }
    }
}
