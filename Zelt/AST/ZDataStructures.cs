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

    public class ZInterface : IComparable<ZInterface>
    {
        public string Name;
        public List<ZFunctionSignature> FunctionSignatures;

        // Don't know if I will have interfaces inherit from other interfaces in the future
        public List<ZInterface> ParentInterfaces;        

        public ZInterface(string name, List<ZInterface>? parentInterfaces = null)
        {
            Name = name;
            ParentInterfaces = parentInterfaces ?? new List<ZInterface>();
            FunctionSignatures = new List<ZFunctionSignature>();
        }

        public static ZInterface Number = new ZInterface("Number");

        public static ZInterface Multiplicative
            = new ZInterface("Multiplicative", new List<ZInterface>() { Number }); // *
        public static ZInterface Divisive
            = new ZInterface("Divisive", new List<ZInterface>() { Number }); // /
        public static ZInterface Modulable
            = new ZInterface("Modulable", new List<ZInterface>() { Number }); // %
        public static ZInterface Additive
            = new ZInterface("Additive", new List<ZInterface>() { Number }); // +
        public static ZInterface Subtractive
            = new ZInterface("Subtractive", new List<ZInterface>() { Number }); // -

        public static ZInterface Comparable = new ZInterface("Comparable"); // <, >, <=, >=
        public static ZInterface Equatable = new ZInterface("Equatable"); // == and !=
        public static ZInterface Negatable = new ZInterface("Negatable"); // !
        public static ZInterface Logical = new ZInterface("Logical"); // && and ||

        public static ZInterface Iterable = new ZInterface("Iterable");
        public static ZInterface Invocable = new ZInterface("Invocable");

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
            // If the type implements the interface directly
            foreach (var @interface in ParentInterfaces)
            {
                if (@interface.CompareTo(other) != 0)
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
        //public List<ZFunction> Functions;
        public List<ZInterface> Interfaces;
        //public ZFunction Constructor;

        public ZStruct(string name)
        {
            Name = name;
            Variables = new List<ZVariable>();
            //Functions = new List<ZFunction>();
            Interfaces = new List<ZInterface>();
            //Constructor = new ZFunction();
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

    public class ZParameterValue
    {
        public string Name;
        public ZType Type;
        public IZExpression? Expression;
        public int Position;

        // Expression can be null if the parameter is not defined, i.e. no default value
        public ZParameterValue(string name, ZType type, IZExpression? expression, int position)
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

    public class ZExpressionStatement : IZStatement
    {
        public IZExpression Expression;

        public ZExpressionStatement(IZExpression expression)
        {
            Expression = expression;
        }
    }

    public class ZReturnStatement : IZStatement
    {
        public List<ZReturnValue> ReturnValues;

        public ZReturnStatement(List<ZReturnValue> returnValues)
        {
            ReturnValues = returnValues;
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
        public List<ZVariable> IteratingVariables;
        // Lists to iterate could be literal lists or variables
        public List<IZExpression> ListsToIterate;
        public List<IZStatement> Body;
    
        public ZEachStatement(List<ZVariable> iteratingVariables, List<IZExpression> listsToIterate, List<IZStatement> body)
        {
            IteratingVariables = iteratingVariables;
            ListsToIterate = listsToIterate;
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
