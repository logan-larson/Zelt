using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Zelt.Grammar;
using Zelt.AST;
using Antlr4.Runtime.Tree;

namespace Zelt.Visitors
{
    public partial class Visitor : ZeltParserBaseVisitor<object>
    {
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
