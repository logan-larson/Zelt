using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Zelt.Grammar;

namespace Zelt.Visitors
{
    public class ProgramVisitor : ZeltParserBaseVisitor<object>
    {

        public override object VisitPrintStatement([NotNull] ZeltParser.PrintStatementContext context)
        {
            Console.WriteLine(context.GetChild(2).GetText());
            return base.VisitPrintStatement(context);
        }

        public override object VisitDeclarationStatement([NotNull] ZeltParser.DeclarationStatementContext context)
        {
            Console.WriteLine($"Declaration Statement: {context.GetText()}");
            return base.VisitDeclarationStatement(context);
        }

        public override object VisitAssignmentStatement([NotNull] ZeltParser.AssignmentStatementContext context)
        {
            Console.WriteLine($"Assignment Statement: {context.GetText()}");
            return base.VisitAssignmentStatement(context);
        }

    }
}
