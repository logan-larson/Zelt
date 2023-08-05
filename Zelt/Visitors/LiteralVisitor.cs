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
    public class LiteralVisitor : ZeltParserBaseVisitor<ZExpression>
    {
        public Dictionary<string, ZType> Types { get; private set; }

        // Caller passes in the currently referenced types (not defined, some could not be defined yet)
        public LiteralVisitor(Dictionary<string, ZType> types)
        {
            Types = types;
        }

        public override ZExpression VisitLiteral([NotNull] ZeltParser.LiteralContext context)
        {
            if (context.INTEGER() != null)
            {
                return new ZLiteralExpression(new ZValue(int.Parse(context.INTEGER().GetText()), Types["Int"]));
            }
            else if (context.FLOAT() != null)
            {
                return new ZLiteralExpression(new ZValue(float.Parse(context.FLOAT().GetText()), Types["Float"]));
            }
            else if (context.STRING() != null)
            {
                return new ZLiteralExpression(new ZValue(context.STRING().GetText(), Types["String"]));
            }
            else if (context.BOOL() != null)
            {
                return new ZLiteralExpression(new ZValue(bool.Parse(context.BOOL().GetText()), Types["Bool"]));
            }
            else if (context.NULL() != null)
            {
                return new ZLiteralExpression(new ZValue((object?)null, Types["Null"]));
            }

            throw new NotImplementedException();
        }

        public override ZExpression VisitList([NotNull] ZeltParser.ListContext context)
        {
            List<ZExpression> values = new List<ZExpression>();

            foreach (var value in context.listElement())
            {
                if (value.DOUBLE_PERIOD() != null)
                {
                    // TODO: Implement range, it needs to be lazily evaluated somehow
                }
                else if (value.expression() != null)
                {
                    if (value.ChildCount > 1)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        values.Add(new ExpressionVisitor(Types).VisitExpression(value.expression()[0]));
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            //return new ZValue(values, Types["List"]);
            return base.VisitList(context);
        }
    }
}
