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
    public class ExpressionVisitor : ZeltParserBaseVisitor<ZExpression>
    {
        public Dictionary<string, ZType> Types { get; private set; }

        // Caller passes in the currently referenced types (not defined, some could not be defined yet)
        public ExpressionVisitor(Dictionary<string, ZType> types)
        {
            Types = types;
        }

        public override ZExpression VisitLiteralExpression([NotNull] ZeltParser.LiteralExpressionContext context)
        {
            return new LiteralVisitor(Types).VisitLiteral(context.literal());
        }

        public override ZExpression VisitListExpression([NotNull] ZeltParser.ListExpressionContext context)
        {
            return base.VisitListExpression(context);
        }

        public override ZExpression VisitIdentifierExpression([NotNull] ZeltParser.IdentifierExpressionContext context)
        {
            string name = context.IDENTIFIER().GetText();

            if (!Types.ContainsKey(name))
            {
                // Type does not exist
                ErrorHandler.ThrowError($"Type '{name}' does not exist.", context.Start.Line, context.Start.Column);
            }

            return new ZIdentifierExpression(name, Types[name]);
        }
    }
}
