using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public class ZProgram
    {
        // TODO: This is wrong, but good for now
        /*
        public List<ZVariable> Variables;
        public List<ZFunction> Functions;
        public List<ZStruct> Structs;
        public List<ZInterface> Interfaces;
        */

        public List<IZStatement> Statements;

        public ZProgram()
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

    public class ZType : IComparable<ZType>
    {
        public string Name;
        public List<ZType> ParentTypes;
        public List<ZInterface> Interfaces;
        public bool IsDefined;

        public ZType(string name, List<ZType>? parentTypes, List<ZInterface>? interfaces, bool isDefined = false)
        {
            Name = name;
            ParentTypes = parentTypes ?? new List<ZType>();
            Interfaces = interfaces ?? new List<ZInterface>();
            IsDefined = isDefined;
        }

        // Primitive types
        public static ZType Int = new ZType("Int", null, new List<ZInterface>()
        {
            ZInterface.Multiplicative,
            ZInterface.Divisive,
            ZInterface.Modulable,
            ZInterface.Additive,
            ZInterface.Subtractive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);
        public static ZType Float = new ZType("Float", null, new List<ZInterface>()
        {
            ZInterface.Multiplicative,
            ZInterface.Divisive,
            ZInterface.Modulable,
            ZInterface.Additive,
            ZInterface.Subtractive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);
        public static ZType String = new ZType("String", null, new List<ZInterface>()
        {
            ZInterface.Additive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);
        public static ZType Bool = new ZType("Bool", null, new List<ZInterface>()
        {
            ZInterface.Equatable,
            ZInterface.Negatable,
        }, true);
        public static ZType Null = new ZType("Null", null, null, true);
        public static ZType Any = new ZType("Any", null, null, true); // Might have to use this for an empty type e.g. a := [] -- would be a := [Any] for now
        /*
        public static ZType Void = new ZType("void", null, true);
        public static ZType Char = new ZType("char", null, true);
        public static ZType Any = new ZType("any", null, true);
        */

        public int CompareTo(ZType? other)
        {
            if (other == null)
            {
                return -1;
            }

            if (Name == other.Name)
            {
                return 0;
            }

            // IDK what this does
            if (ParentTypes.Contains(other))
            {
                return 1;
            }

            return -1;
        }

        public bool Implements(ZInterface other)
        {
            // If the type implements the interface directly
            if (Interfaces.Contains(other))
            {
                return true;
            }

            // If the type implements the interface through one of its interfaces' parent interfaces
            foreach (var i in Interfaces)
            {
                if (i.Implements(other))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class ZListType : ZType
    {
        public ZType ElementType;

        public ZListType(ZType? elementType) : base($"[{elementType?.Name}]", null, null, true)
        {
            ElementType = elementType ?? ZType.Any;
        }
    }

    public class ZInterface : IComparable<ZInterface>
    {
        public string Name;
        public List<ZFunctionSignature> FunctionSignatures;

        // Don't know if I will have interfaces inherit from other interfaces in the future
        public List<ZInterface> ParentInterfaces;        

        public ZInterface(string name)
        {
            Name = name;
            FunctionSignatures = new List<ZFunctionSignature>();
            ParentInterfaces = new List<ZInterface>();
        }

        public static ZInterface Multiplicative = new ZInterface("Multiplicative"); // *
        public static ZInterface Divisive = new ZInterface("Divisive"); // /
        public static ZInterface Modulable = new ZInterface("Modulable"); // %
        public static ZInterface Additive = new ZInterface("Additive"); // +
        public static ZInterface Subtractive = new ZInterface("Subtractive"); // -
        public static ZInterface Comparable = new ZInterface("Comparable"); // <, >, <=, >=
        public static ZInterface Equatable = new ZInterface("Equatable"); // == and !=
        public static ZInterface Negatable = new ZInterface("Negatable"); // !

        public int CompareTo(ZInterface? other)
        {
            if (other == null)
            {
                return -1;
            }

            if (Name == other.Name)
            {
                return 0;
            }

            // IDK what this does
            if (ParentInterfaces.Contains(other))
            {
                return 1;
            }

            return -1;
        }

        public bool Implements(ZInterface other)
        {
            // If this interface directly implements the other interface
            if (ParentInterfaces.Contains(other))
            {
                return true;
            }

            // If this interface implements the other interface through one of its parent interfaces
            foreach (var parentInterface in ParentInterfaces)
            {
                if (parentInterface.Implements(other))
                {
                    return true;
                }
            }

            return false;
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

        public int Line { get; set; }
        public int Column { get; set; }

        public ZVariable(string name, ZType type, bool isDefined = false)
        {
            Name = name;
            Type = type;
            IsDefined = isDefined;
        }
    }

    /*
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
    */

    public class ZParameterValue
    {
        public string Name;
        public ZType Type;
        public IZExpression Expression;
        public int Position;

        public ZParameterValue(string name, ZType type, IZExpression expression, int position)
        {
            Name = name;
            Type = type;
            Expression = expression;
            Position = position;
        }
    }

    public class ZReturnValue
    {
        public ZType Type;
        public IZExpression Expression;
        public int Position;

        public ZReturnValue(ZType type, IZExpression expression, int position)
        {
            Type = type;
            Expression = expression;
            Position = position;
        }
    }

    public class ZAssignment
    {
        public ZVariable Variable;
        public IZExpression Expression;
        public bool IsDeclaration;

        public ZAssignment(ZVariable variable, IZExpression expression, bool isDeclaration)
        {
            Variable = variable;
            Expression = expression;
            IsDeclaration = isDeclaration;
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

    public class ZAssignmentStatement : IZStatement
    {
        public List<ZAssignment> Assignments;

        public ZAssignmentStatement(List<ZAssignment> assignments)
        {
            Assignments = assignments;
        }
    }

    public class ZWhileStatement : IZStatement
    {
        public IZExpression Condition;
        public List<IZStatement> Body;

        public ZWhileStatement(IZExpression condition, List<IZStatement> body)
        {
            Condition = condition;
            Body = body;
        }
    }

    public class ZIfStatement : IZStatement
    {
        public IZExpression Condition;
        public List<IZStatement> TrueBody;
        public List<IZStatement> FalseBody;

        public ZIfStatement(IZExpression condition, List<IZStatement> trueBody, List<IZStatement> falseBody)
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
        public List<IZExpression> Values;

        public ZList(ZType type, List<IZExpression> values)
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
