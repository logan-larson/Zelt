using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public class ZAST
    {
        // TODO: This is wrong, but good for now
        /*
        public List<ZVariable> Variables;
        public List<ZFunction> Functions;
        public List<ZStruct> Structs;
        public List<ZInterface> Interfaces;
        */

        public List<IZStatement> Statements;

        public ZAST()
        {
            Statements = new List<IZStatement>();
            /*
            Variables = new List<ZVariable>();
            Functions = new List<ZFunction>();
            Structs = new List<ZStruct>();
            Interfaces = new List<ZInterface>();
            */
        }
    }

    public class ZType
    {
        public string Name;
        public List<ZType> ParentTypes;
        public bool IsDefined;
        //public List<ZInterface> Interfaces;

        public ZType(string name, List<ZType>? parentTypes, bool isDefined = false)
        {
            Name = name;
            ParentTypes = parentTypes ?? new List<ZType>();
            IsDefined = isDefined;
            //Interfaces = new List<ZInterface>();
        }
    }

    public class ZInterface
    {
        public string Name;
        public List<ZFunctionSignature> FunctionSignatures;
        
        public ZInterface(string name)
        {
            Name = name;
            FunctionSignatures = new List<ZFunctionSignature>();
        }
    }

    public class ZStruct
    {
        public string Name;
        public List<ZVariable> Variables;
        // IDK where these should go
        public List<ZFunction> Functions;
        public List<ZInterface> Interfaces;
        public ZFunction Constructor;

        public ZStruct(string name)
        {
            Name = name;
            Variables = new List<ZVariable>();
            Functions = new List<ZFunction>();
            Interfaces = new List<ZInterface>();
            Constructor = new ZFunction();
        }
    }

    public class ZStructInstance
    {
        public List<ZVariable> Variables;

        // Do I need a name?
        public string Name;

        public ZStructInstance(string name)
        {
            Variables = new List<ZVariable>();
            Name = name;
        }
    }

    public class ZFunctionSignature
    {
        public string Name;
        public bool HasCaller;
        public List<ZParameterType> ParameterTypes;
        public List<ZReturnType> ReturnTypes;

        public ZFunctionSignature(string name, bool hasCaller = false)
        {
            Name = name;
            HasCaller = hasCaller;
            ParameterTypes = new List<ZParameterType>();
            ReturnTypes = new List<ZReturnType>();
        }
    }

    public class ZParameterType
    {
        public int Position;
        public ZType Type;

        public ZParameterType(int position, ZType type)
        {
            Position = position;
            Type = type;
        }
    }

    public class ZReturnType
    {
        public int position;
        public ZType Type;

        public ZReturnType(int position, ZType type)
        {
            this.position = position;
            Type = type;
        }
    }

    public class ZFunction
    {
        public ZVariable CallerName;
        public string Name;
        public List<ZParameterValue> ParameterValues;
        public List<ZReturnValue> ReturnValues;
        public List<IZStatement> Body;

        public ZFunction()
        {
            throw new NotImplementedException();
            /*
            CallerName = new ZVariable();
            Name = "";
            ParameterValues = new List<ZParameterValue>();
            ReturnValues = new List<ZReturnValue>();
            Body = new List<IZStatement>();
            */
        }
    }

    public class ZStructConstructor
    {
        public ZStruct Struct;

        public ZStructConstructor(ZStruct zStruct)
        {
            Struct = zStruct;
        }
    }

    public class ZDeclaration
    {
        public ZVariable Variable;

        public ZDeclaration(ZVariable variable)
        {
            Variable = variable;
        }
    }

    public class ZVariable : IZDeclarationMetaData
    {
        public string Name;
        public bool IsDefined;
        public ZType Type;
        public ZValue Value;

        public int Line { get; set; }
        public int Column { get; set; }

        public ZVariable(string name, ZType type, ZValue? value, bool isDefined = false)
        {
            Name = name;
            Type = type;
            Value = value ?? new ZValue((object?)null, new ZType("Null", null, true));
            IsDefined = isDefined;
        }
    }

    public class ZValue
    {
        public ZType Type;

        public int? IntValue;
        public float? FloatValue;
        public string? StringValue;
        public bool? BoolValue;
        public ZList? ListValue;

        public ZValue(int value, ZType type)
        {
            IntValue = value;
            Type = type;
        }

        public ZValue(float value, ZType type)
        {
            FloatValue = value;
            Type = type;
        }

        public ZValue(string value, ZType type)
        {
            StringValue = value;
            Type = type;
        }

        public ZValue(bool value, ZType type)
        {
            BoolValue = value;
            Type = type;
        }

        public ZValue(ZList value, ZType type)
        {
            ListValue = value;
            Type = type;
        }

        public ZValue(object? _, ZType type) // Nulls??
        {
            Type = type;
        }
    }

    public class ZParameterValue
    {
        public string Name;
        public ZType Type;
        public ZValue Value;
        public int Position;

        public ZParameterValue(string name, ZType type, ZValue value, int position)
        {
            Name = name;
            Type = type;
            Value = value;
            Position = position;
        }
    }

    public class ZReturnValue
    {
        public ZType Type;
        public ZValue Value;
        public int Position;

        public ZReturnValue(ZType type, ZValue value, int position)
        {
            Type = type;
            Value = value;
            Position = position;
        }
    }

    // -- Statements --

    public interface IZStatement { }

    public class ZDeclarationStatement : IZStatement
    {
        public List<ZDeclaration> Declarations;

        public ZDeclarationStatement(List<ZDeclaration> declarations)
        {
            Declarations = declarations;
        }
    }

    public class ZWhileStatement : IZStatement
    {
        public ZExpression Condition;
        public List<IZStatement> Body;

        public ZWhileStatement(ZExpression condition, List<IZStatement> body)
        {
            Condition = condition;
            Body = body;
        }
    }

    public class ZIfStatement : IZStatement
    {
        public ZExpression Condition;
        public List<IZStatement> TrueBody;
        public List<IZStatement> FalseBody;

        public ZIfStatement(ZExpression condition, List<IZStatement> trueBody, List<IZStatement> falseBody)
        {
            Condition = condition;
            TrueBody = trueBody;
            FalseBody = falseBody;
        }
    }

    public class ZEachStatement : IZStatement
    {
        public ZVariable IteratingVariable;
        public ZList ListToIterate;
        public List<IZStatement> Body;


        public ZEachStatement(ZVariable iteratingVariable, ZList listToIterate, List<IZStatement> body)
        {
            IteratingVariable = iteratingVariable;
            ListToIterate = listToIterate;
            Body = body;
        }
    }

    public class ZList
    {
        public ZType Type;
        public List<ZExpression> Values;

        public ZList(ZType type, List<ZExpression> values)
        {
            Type = type;
            Values = values;
        }
    }


    public interface IZDeclarationMetaData
    {
        int Line { get; set; }
        int Column { get; set; }
    }
}
