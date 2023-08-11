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
        public string[] SourceCodeLines { get; private set; }

        public TypeVisitor(Dictionary<string, ZType> types, string[] sourceCodeLines)
        {
            Types = types;
            SourceCodeLines = sourceCodeLines;
        }

        public override ZType VisitType([NotNull] ZeltParser.TypeContext context)
        {
            // Check if the type is already defined
            if (context.IDENTIFIER() != null && Types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
            {
                return type;
            }

            if (context.functionType() is not null)
            {
                return VisitFunctionType(context.functionType());
            }

            if (context.functionCallerType() is not null)
            {
                return VisitFunctionCallerType(context.functionCallerType());
            }

            if (context.listType() is not null)
            {
                return VisitListType(context.listType());
            }
            
            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null);

            Types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }

        public override ZType VisitCallerType([NotNull] ZeltParser.CallerTypeContext context)
        {
            // Check if the type is already defined
            if (context.IDENTIFIER() != null && Types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
            {
                return type;
            }

            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null);

            Types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }

        public override ZListType VisitListType([NotNull] ZeltParser.ListTypeContext context)
        {
            ZType type = VisitType(context.type());

            return new ZListType(type);
        }

        public override ZFunctionType VisitFunctionType([NotNull] ZeltParser.FunctionTypeContext context)
        {
            List<ZType> parameterTypes = new List<ZType>();

            foreach (var type in context.parameterTypeList().type())
            {
                parameterTypes.Add(VisitType(type));
            }

            List<ZType> returnTypes = new List<ZType>();

            foreach (var type in context.returnTypeList().type())
            {
                returnTypes.Add(VisitType(type));
            }

            return new ZFunctionType(parameterTypes, returnTypes);
        }

        public override ZType VisitFunctionCallerType([NotNull] ZeltParser.FunctionCallerTypeContext context)
        {
            ZType callerType = VisitCallerType(context.callerType());

            List<ZType> parameterTypes = new List<ZType>();

            foreach (var type in context.parameterTypeList().type())
            {
                parameterTypes.Add(VisitType(type));
            }

            List<ZType> returnTypes = new List<ZType>();

            foreach (var type in context.returnTypeList().type())
            {
                returnTypes.Add(VisitType(type));
            }

            return new ZFunctionType(parameterTypes, returnTypes, callerType);
        }
    }
}
