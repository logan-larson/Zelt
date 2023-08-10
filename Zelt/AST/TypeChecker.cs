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

        public static void TypeImplements(ZType type, ZInterface @interface, int line, int column, string[] sourceCodeLines)
        {
            if (type == null)
            {
                ErrorHandler.ThrowError($"Type provided is null.", line, column, sourceCodeLines);
                return;
            }

            if (@interface == null)
            {
                ErrorHandler.ThrowError($"Interface provided is null.", line, column, sourceCodeLines);
                return;
            }
            
            if (!type.Implements(@interface))
            {
                ErrorHandler.ThrowError($"{type.Name} does not implement the {@interface.Name} interface.", line, column, sourceCodeLines);
            }
        }

        /*
        public static void TypeEquals(ZType first, ZType second, int line, int column, string[] sourceCodeLines)
        {
            if (first == null)
            {
                ErrorHandler.ThrowError("Type providied is null.", line, column, sourceCodeLines);
                return;
            }

            if (second == null)
            {
                ErrorHandler.ThrowError("Type provided is null.", line, column, sourceCodeLines);
                return;
            }

            if (first.CompareTo(second) != 0)
            {
                ErrorHandler.ThrowError($"Cannot compare types {left.Type.Name} and {right.Type.Name}", context.Start.Line, context.Start.Column, SourceCodeLines);
            }
        }
        */
    }
}
