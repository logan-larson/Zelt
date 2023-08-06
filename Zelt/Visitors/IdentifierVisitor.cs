using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;
using Zelt.Grammar;

namespace Zelt.Visitors
{
    public class IdentifierVisitor : ZeltParserBaseVisitor<IZExpression>
    {
        public Dictionary<string, ZType> Types { get; private set; }
        public Dictionary<string, ZVariable> Variables { get; private set; }

        // Caller passes in the currently referenced types (not defined, some could not be defined yet)
        public IdentifierVisitor(Dictionary<string, ZType> types, Dictionary<string, ZVariable> variables)
        {
            Types = types;
            Variables = variables;
        }
    }
}
