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
    public class TypeVisitor : ZeltParserBaseVisitor<ZType>
    {
        public Dictionary<string, ZType> Types { get; private set; }

        public TypeVisitor(Dictionary<string, ZType> types)
        {
            Types = types;
        }

        public override ZType VisitType([NotNull] ZeltParser.TypeContext context)
        {
            // If the type is already defined, return it
            if (Types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
            {
                return type;
            }
            
            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null, null);

            Types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }
    }
}
