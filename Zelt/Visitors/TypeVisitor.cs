﻿using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;
using Zelt.Grammar;

namespace Zelt.Visitors
{
    /// <summary>
    /// Visits types.
    /// </summary>
    public class TypeVisitor : ZeltParserBaseVisitor<ZType>
    {
        private Dictionary<string, ZType> _types { get; set; }
        private string[] _sourceCodeLines { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeVisitor"/> class.
        /// </summary>
        /// <param name="types">The types known to this scope.</param>
        /// <param name="sourceCodeLines">The source code lines.</param>
        public TypeVisitor(Dictionary<string, ZType> types, string[] sourceCodeLines)
        {
            _types = types;
            _sourceCodeLines = sourceCodeLines;
        }

        /// <summary>
        /// Visits a type.
        /// </summary>
        /// <param name="context">The parser tree context.</param>
        /// <returns>A <see cref="ZType"/> node.</returns>
        public override ZType VisitType([NotNull] ZeltParser.TypeContext context)
        {
            // Check if the type is already defined
            if (context.IDENTIFIER() != null && _types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
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

            if (context.structType() is not null)
            {
                return VisitStructType(context.structType());
            }

            if (context.listType() is not null)
            {
                return VisitListType(context.listType());
            }
            
            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null);

            _types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override ZType VisitCallerType([NotNull] ZeltParser.CallerTypeContext context)
        {
            // Check if the type is already defined
            if (context.IDENTIFIER() != null && _types.TryGetValue(context.IDENTIFIER().GetText(), out ZType? type))
            {
                return type;
            }

            // Otherwise, create a new type and set its defined to false
            // If the type is never defined, the type checker will throw an error
            ZType newType = new ZType(context.IDENTIFIER().GetText(), null);

            _types.Add(context.IDENTIFIER().GetText(), newType);

            return newType;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override ZListType VisitListType([NotNull] ZeltParser.ListTypeContext context)
        {
            ZType type = VisitType(context.type());

            return new ZListType(type);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override ZType VisitStructType([NotNull] ZeltParser.StructTypeContext context)
        {
            List<ZType> memberTypes = new List<ZType>();

            foreach (var type in context.parameterTypeList().type())
            {
                memberTypes.Add(VisitType(type));
            }

            return new ZStructType(memberTypes);
        }
    }
}
