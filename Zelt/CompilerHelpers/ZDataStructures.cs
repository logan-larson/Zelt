using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.CompilerHelpers
{
    public interface ICodeGen
    {
        void CodeGen(StreamWriter stream);
    }

    public class ZType
    {
        public string Name;
        public bool IsDefined;
        public List<ZInterface> Interfaces;

        public ZType(string name, bool isDefined = false)
        {
            Name = name;
            IsDefined = isDefined;
            Interfaces = new List<ZInterface>();
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

    public class ZStruct : ICodeGen
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

        public void CodeGen(StreamWriter stream)
        {
            stream.WriteLine($"function {this.Name}() {{");
            foreach (var variable in this.Variables)
            {
                stream.WriteLine($"\tthis.{variable.Name} = {variable.Value};");
            }
            stream.WriteLine("}");
        }
    }

    public class ZStructInstance : ICodeGen
    {
        public List<ZVariable> Variables;

        // Do I need a name?
        public string Name;

        public ZStructInstance(string name)
        {
            Variables = new List<ZVariable>();
            Name = name;
        }

        public void CodeGen(StreamWriter stream)
        {
            stream.WriteLine($"new {this.Name}() {{");
            foreach (var variable in this.Variables)
            {
                stream.WriteLine($"\tthis.{variable.Name} = {variable.Value};");
            }
            stream.WriteLine("}");
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

    public class ZFunction : ICodeGen
    {
        public ZVariable CallerName;
        public string Name;
        public List<ZParameterValue> ParameterValues;
        public List<ZReturnValue> ReturnValues;
        public List<IZStatement> Body;

        public ZFunction()
        {
            CallerName = new ZVariable();
            Name = "";
            ParameterValues = new List<ZParameterValue>();
            ReturnValues = new List<ZReturnValue>();
            Body = new List<IZStatement>();
        }

        public void CodeGen(StreamWriter stream)
        {
            List<string> parameterValues = ParameterValues.OrderBy(p => p.Position).Select(p => p.Name).ToList();

            if (CallerName.IsDefined)
            {
                parameterValues.Insert(0, CallerName.Name);
            }

            string parameters = string.Join(", ", parameterValues);

            stream.WriteLine($"function {this.Name}({parameters}) {{");
            foreach (var statement in this.Body)
            {
                statement.CodeGen(stream);
            }
            stream.WriteLine("}");
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

        public ZVariable(string name, ZType type, ZValue value, bool isDefined = false)
        {
            Name = name;
            IsDefined = isDefined;
            Type = type;
            Value = value;
        }

        public ZVariable()
        {
            Name = "";
            IsDefined = false;
            Type = new ZType("");
            Value = new ZValue("");
        }

        public void CodeGen(StreamWriter stream)
        {
            //stream.WriteLine($"var {this.Name} = {this.Value};");
            throw new NotImplementedException();
        }
    }

    public class ZValue
    {
        public int? intValue;
        public float? floatValue;
        public string? stringValue;
        public bool? boolValue;

        public ZValue(int value)
        {
            intValue = value;
        }

        public ZValue(float value)
        {
            floatValue = value;
        }

        public ZValue(string value)
        {
            stringValue = value;
        }

        public ZValue(bool value)
        {
            boolValue = value;
        }

        public void CodeGen(StreamWriter stream)
        {
            if (intValue.HasValue)
            {
                stream.Write(intValue.Value);
            }
            else if (floatValue.HasValue)
            {
                stream.Write(floatValue.Value);
            }
            else if (stringValue is not null)
            {
                stream.Write($"\"{stringValue}\"");
            }
            else if (boolValue.HasValue)
            {
                stream.Write(boolValue.Value);
            }
            else
            {
                throw new Exception("Invalid value");
            }
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

        public void CodeGen(StreamWriter stream)
        {
            stream.Write($"{this.Name}");
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

        public void CodeGen(StreamWriter stream)
        {
            stream.Write($"{this.Value}");
        }
    }

    // -- Statements --

    public interface IZStatement : ICodeGen { }

    public class ZWhileStatement : IZStatement
    {
        public ZExpression Condition;
        public List<IZStatement> Body;

        public ZWhileStatement(ZExpression condition, List<IZStatement> body)
        {
            Condition = condition;
            Body = body;
        }

        public void CodeGen(StreamWriter streamWriter)
        {             
            throw new NotImplementedException();
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

        public void CodeGen(StreamWriter streamWriter)
        {             
            throw new NotImplementedException();
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

        public void CodeGen(StreamWriter streamWriter)
        {             
            throw new NotImplementedException();
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

        public void CodeGen(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }

    public class ZExpression
    {
        public ZType Type;
        public ZValue Value;

        public ZExpression(ZType type, ZValue value)
        {
            Type = type;
            Value = value;
        }

        public void CodeGen(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }




    public interface IZDeclarationMetaData
    {
        int Line { get; set; }
        int Column { get; set; }
    }
}
