using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public static class TypeChecker
    {
        public static void CheckVariableDeclarationTypes(Dictionary<string, ZVariable> variables, string[] sourceCodeLines)
        {
            foreach (var variable in variables)
            {
                if (variable.Value.Type is ZListType listType)
                {
                    if (!listType.ElementType.IsDefined)
                    {
                        ErrorHandler.ThrowError($"Type '{listType.ElementType.Name}' was not defined. Type of '{variable.Key}'", variable.Value.Line, variable.Value.Column, sourceCodeLines);
                    }
                }
                else if (variable.Value.Type is ZType zType)
                {
                    if (!zType.IsDefined)
                    {
                        ErrorHandler.ThrowError($"Type '{variable.Value.Type.Name}' was not defined. Type of '{variable.Key}'", variable.Value.Line, variable.Value.Column, sourceCodeLines);
                    }
                }
            }
        }
    }
}
