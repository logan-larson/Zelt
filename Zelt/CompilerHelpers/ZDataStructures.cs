using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.CompilerHelpers
{
    public struct ZType
    {
        public string name;
        public bool isDefined;
        public List<ZInterface> interfaces;

        public ZType(string name, bool isDefined = false)
        {
            this.name = name;
            this.isDefined = isDefined;
            this.interfaces = new List<ZInterface>();
        }
    }

    public struct ZInterface
    {
        public string name;
        public List<ZFunctionSignature> functionSignatures;
    }

    public struct ZStruct
    {
        public List<ZVariable> variables;
        // IDK where these should go
        public List<ZFunction> functions;
        public List<ZInterface> interfaces;
        public ZFunction constructor;
    }

    public struct ZStructInstance
    {
        public List<ZVariable> variables;
    }

    public struct ZFunctionSignature
    {
        public string name;
        public bool hasCaller;
        public List<ZParameterType> parameterTypes;
        public List<ZReturnType> returnTypes;
    }

    public struct ZParameterType
    {
        public int position;
        public ZType type;
    }

    public struct ZReturnType
    {
        public int position;
        public ZType type;
    }

    public struct ZFunction
    {
        public ZVariable callerName;
        public string name;
        public List<ZParameterValues> parameterValues;
        public List<ZReturnValues> returnValues;
        public List<IZStatement> body;
    }

    public struct ZVariable : IZDeclarationMetaData
    {
        public string name;
        public bool isDefined;
        public ZType type;
        public ZValue value;

        public int Line { get; set; }
        public int Column { get; set; }
    }

    public struct ZValue
    {
        public int? intValue;
        public float? floatValue;
        public string? stringValue;
        public bool? boolValue;
    }

    public struct ZParameterValues
    {
        public string name;
        public ZType type;
        public ZValue value;
        public int position;
    }

    public struct ZReturnValues
    {
        public ZType type;
        public ZValue value;
        public int position;
    }

    // -- Statements --

    public interface IZStatement { }

    public struct ZWhileStatement : IZStatement
    {
        public ZExpression condition;
        public List<IZStatement> body;
    }

    public struct ZIfStatement : IZStatement
    {
        public ZExpression condition;
        public List<IZStatement> trueBody;
        public List<IZStatement> falseBody;
    }

    public struct ZEachStatement : IZStatement
    {
        public ZVariable iteratingVariable;
        public ZList listToIterate;
        public List<IZStatement> body;
    }

    public struct ZList
    {
        public ZType type;
        public List<ZExpression> values;
    }

    public struct ZExpression
    {
        public ZType type;
        public ZValue value;
    }




    public interface IZDeclarationMetaData
    {
        int Line { get; set; }
        int Column { get; set; }
    }
}
