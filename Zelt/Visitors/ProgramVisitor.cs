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
            Console.WriteLine($"\n{context.GetChild(2).GetText()}\n");
            return base.VisitPrintStatement(context);
        }

        public override object VisitDeclarationStatement([NotNull] ZeltParser.DeclarationStatementContext context)
        {
            Console.WriteLine($"Declaration Statement: {context.GetText()}\n");
            return base.VisitDeclarationStatement(context);
        }

        public override object VisitAssignmentStatement([NotNull] ZeltParser.AssignmentStatementContext context)
        {
            Console.WriteLine($"Assignment Statement: {context.GetText()}\n");
            return base.VisitAssignmentStatement(context);
        }

        public override object VisitFunctionCallStatement([NotNull] ZeltParser.FunctionCallStatementContext context)
        {
            Console.WriteLine($"Function Call Statement: {context.GetText()}\n");
            return base.VisitFunctionCallStatement(context);
        }

        public override object VisitFunctionDeclaration([NotNull] ZeltParser.FunctionDeclarationContext context)
        {
            Console.WriteLine($"Function Declaration: {context.GetText()}\n");
            return base.VisitFunctionDeclaration(context);
        }

        public override object VisitInterfaceDeclaration([NotNull] ZeltParser.InterfaceDeclarationContext context)
        {
            Console.WriteLine($"Interface Declaration: {context.GetText()}\n");
            return base.VisitInterfaceDeclaration(context);
        }

        public override object VisitStructDeclaration([NotNull] ZeltParser.StructDeclarationContext context)
        {
            Console.WriteLine($"Struct Declaration: {context.GetText()}\n");
            return base.VisitStructDeclaration(context);
        }



    }
}
