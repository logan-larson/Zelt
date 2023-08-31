using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    /// <summary>
    /// Represents a Zelt program
    /// </summary>
    public class ZProgram
    {
        /// <summary>
        /// The statements that make up the program
        /// </summary>
        public List<ZStatement> Statements { get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZProgram"/> class.
        /// </summary>
        public ZProgram()
        {
            Statements = new List<ZStatement>();
        }
    }

    /// <summary>
    /// Represents an interface that can be implemented by a type/struct
    /// </summary>
    public class ZInterface : IComparable<ZInterface>
    {
        /// <summary>
        /// Name of the interface
        /// </summary>
        public string Name;

        /// <summary>
        /// The function signatures that the interface defines
        /// </summary>
        public List<ZFunctionSignature> FunctionSignatures;

        /// <summary>
        /// Collection of interfaces that this interface inherits from
        /// </summary>
        // Don't know if I will have interfaces inherit from other interfaces in the future
        public List<ZInterface> ParentInterfaces;        

        /// <summary>
        /// Initializes a new instance of the <see cref="ZInterface"/> class.
        /// </summary>
        /// <param name="name">The name of the interface.</param>
        /// <param name="parentInterfaces">List of interfaces that this interface inherits from.</param>
        public ZInterface(string name, List<ZInterface>? parentInterfaces = null)
        {
            Name = name;
            ParentInterfaces = parentInterfaces ?? new List<ZInterface>();
            FunctionSignatures = new List<ZFunctionSignature>();
        }

        #region Built-in Interfaces

        /// <summary>
        /// Number interface, used for numeric types.
        /// The multiplicative, divisive, additive, and subtractive interfaces inherit from this interface
        /// </summary>
        public static ZInterface Number = new ZInterface("Number");

        /// <summary>
        /// Multiplicative interface. Allows for the use of the (*) operator.
        /// </summary>
        public static ZInterface Multiplicative
            = new ZInterface("Multiplicative", new List<ZInterface>() { Number });

        /// <summary>
        /// Divisive interface. Allows for the use of the (/) operator.
        /// </summary>
        public static ZInterface Divisive
            = new ZInterface("Divisive", new List<ZInterface>() { Number });

        /// <summary>
        /// Modulable interface. Allows for the use of the (%) operator.
        /// </summary>
        public static ZInterface Modulable
            = new ZInterface("Modulable", new List<ZInterface>() { Number });

        /// <summary>
        /// Additive interface. Allows for the use of the (+) operator.
        /// </summary>
        public static ZInterface Additive
            = new ZInterface("Additive", new List<ZInterface>() { Number });

        /// <summary>
        /// Subtractive interface. Allows for the use of the (-) operator.
        /// </summary>
        public static ZInterface Subtractive
            = new ZInterface("Subtractive", new List<ZInterface>() { Number });

        /// <summary>
        /// Comparable interface. Allows for the use of the (&lt;, &gt;, &lt;=, &gt;=) operators.
        /// </summary>
        public static ZInterface Comparable = new ZInterface("Comparable");

        /// <summary>
        /// Equatable interface. Allows for the use of the (==, !=) operators.
        /// </summary>
        public static ZInterface Equatable = new ZInterface("Equatable");
        
        /// <summary>
        /// Negatable interface. Allows for the use of the (!) operator.
        /// </summary>
        public static ZInterface Negatable = new ZInterface("Negatable");

        /// <summary>
        /// Logical interface. Allows for the use of the (&amp;&amp;, ||) operators.
        /// </summary>
        public static ZInterface Logical = new ZInterface("Logical");

        /// <summary>
        /// Iterable interface. Allows for the type to be iterated over as a collection.
        /// </summary>
        public static ZInterface Iterable = new ZInterface("Iterable");

        /// <summary>
        /// Invocable interface. Allows for the type to be invoked as a function.
        /// </summary>
        public static ZInterface Invocable = new ZInterface("Invocable");

        #endregion

        /// <summary>
        /// Compares this interface to another interface.
        /// </summary>
        /// <param name="other">The other interface to compare to.</param>
        /// <returns>0 if the interfaces are the same, 1 if this interface inherits from the other interface, -1 otherwise.</returns>
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

            // Might need to recursively check if the interface inherits from the other interface
            if (ParentInterfaces.Contains(other))
            {
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// Checks if this interface implements the other interface.
        /// </summary>
        /// <param name="other">The other interface to check.</param>
        /// <returns>True if this interface implements the other interface, false otherwise.</returns>
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

    /// <summary>
    /// Represents a struct type.
    /// </summary>
    public class ZStruct
    {
        /// <summary>
        /// Name of the struct.
        /// </summary>
        public string Name;

        /// <summary>
        /// Variables that the struct contains.
        /// </summary>
        public List<ZVariable> Variables;

        /// <summary>
        /// Interfaces that the struct implements.
        /// </summary>
        public List<ZInterface> Interfaces;


        // IDK where these should go
        //public List<ZFunction> Functions;
        //public ZFunction Constructor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZStruct"/> class.
        /// </summary>
        /// <param name="name">Name of the struct.</param>
        public ZStruct(string name)
        {
            Name = name;
            Variables = new List<ZVariable>();
            Interfaces = new List<ZInterface>();

            //Functions = new List<ZFunction>();
            //Constructor = new ZFunction();
        }
    }

    /// <summary>
    /// Represents a function signature.
    /// </summary>
    public class ZFunctionSignature
    {
        /// <summary>
        /// Name of the function.
        /// </summary>
        public string Name;

        /// <summary>
        /// Flag indicating if the function has a caller.
        /// </summary>
        public bool HasCaller;

        /// <summary>
        /// Types of the parameters.
        /// </summary>
        public List<ZParameterType> ParameterTypes;

        /// <summary>
        /// Types of the return values.
        /// </summary>
        public List<ZReturnType> ReturnTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZFunctionSignature"/> class.
        /// </summary>
        /// <param name="name">Name of the function.</param>
        /// <param name="hasCaller">Flag indicating if the function has a caller.</param>
        public ZFunctionSignature(string name, bool hasCaller = false)
        {
            Name = name;
            HasCaller = hasCaller;
            ParameterTypes = new List<ZParameterType>();
            ReturnTypes = new List<ZReturnType>();
        }
    }

    /// <summary>
    /// Represents a parameter type in the function's parameter list.
    /// </summary>
    public class ZParameterType
    {
        /// <summary>
        /// Position of the parameter in the function's parameter list.
        /// </summary>
        public int Position;

        /// <summary>
        /// Type of the parameter.
        /// </summary>
        public ZType Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZParameterType"/> class.
        /// </summary>
        /// <param name="position">Position of the parameter in the function's parameter list.</param>
        /// <param name="type">Type of the parameter.</param>
        public ZParameterType(int position, ZType type)
        {
            Position = position;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a return type in the function's return types list.
    /// </summary>
    public class ZReturnType
    {
        /// <summary>
        /// Position of the return type in the function's return types list.
        /// </summary>
        public int position;

        /// <summary>
        /// Type of the return type.
        /// </summary>
        public ZType Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZReturnType"/> class.
        /// </summary>
        /// <param name="position">Position of the return type in the function's return types list.</param>
        /// <param name="type">Type of the return type.</param>
        public ZReturnType(int position, ZType type)
        {
            this.position = position;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a constructor for a <see cref="ZStruct"/>.
    /// </summary>
    public class ZStructConstructor
    {
        /// <summary>
        /// Struct that the constructor is for.
        /// </summary>
        public ZStruct Struct;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZStructConstructor"/> class.
        /// </summary>
        /// <param name="struct">Struct that the constructor is for.</param>
        public ZStructConstructor(ZStruct @struct)
        {
            Struct = @struct;
        }
    }

    /// <summary>
    /// Represents a declaration of a <see cref="ZVariable"/>
    /// </summary>
    public class ZDeclaration
    {
        /// <summary>
        /// Variable that is being declared.
        /// </summary>
        public ZVariable Variable;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZDeclaration"/> class.
        /// </summary>
        /// <param name="variable">Variable that is being declared.</param>
        public ZDeclaration(ZVariable variable)
        {
            Variable = variable;
        }
    }

    /// <summary>
    /// Represents a variable.
    /// </summary>
    public class ZVariable : IZDeclarationMetaData
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        public string Name;
        
        /// <summary>
        /// Flag indicating if the variable is defined.
        /// </summary>
        public bool IsDefined;

        /// <summary>
        /// Type of the variable.
        /// </summary>
        public ZType Type;

        /// <summary>
        /// Line of the source code where the variable is declared.
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Column of the source code where the variable is declared.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZVariable"/> class.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="type">Type of the variable.</param>
        /// <param name="isDefined">Flag indicating if the variable is defined.</param>
        public ZVariable(string name, ZType type, bool isDefined = false)
        {
            Name = name;
            Type = type;
            IsDefined = isDefined;
        }
    }

    /// <summary>
    /// Represents a parameter in a function.
    /// </summary>
    public class ZParameterValue
    {
        /// <summary>
        /// Name of the parameter.
        /// </summary>
        public string Name;
        
        /// <summary>
        /// Type of the parameter.
        /// </summary>
        public ZType Type;

        /// <summary>
        /// Expression that is used as the default value for the parameter, if any.
        /// </summary>
        public IZExpression? Expression;

        /// <summary>
        /// Position of the parameter in the function's parameter list.
        /// </summary>
        public int Position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZParameterValue"/> class.
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="type">Type of the parameter.</param>
        /// <param name="position">Position of the parameter in the function's parameter list.</param>
        /// <param name="expression">Expression that is used as the default value for the parameter, if any.</param>
        public ZParameterValue(string name, ZType type, int position, IZExpression? expression = null)
        {
            Name = name;
            Type = type;
            Expression = expression;
            Position = position;
        }
    }

    /// <summary>
    /// Represents a return value in a function.
    /// </summary>
    public class ZReturnValue
    {
        /// <summary>
        /// Type of the return value.
        /// </summary>
        public ZType Type;

        /// <summary>
        /// Expression for the return value.
        /// </summary>
        public IZExpression Expression;

        /// <summary>
        /// Position of the return value in the function's return values list.
        /// </summary>
        public int Position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZReturnValue"/> class.
        /// </summary>
        /// <param name="type">Type of the return value.</param>
        /// <param name="expression">Expression for the return value.</param>
        /// <param name="position">Position of the return value in the function's return values list.</param>
        public ZReturnValue(ZType type, IZExpression expression, int position)
        {
            Type = type;
            Expression = expression;
            Position = position;
        }
    }

    /// <summary>
    /// Represents an assignment of an expression to a variable.
    /// </summary>
    public class ZAssignment
    {
        /// <summary>
        /// Variable that is being assigned to.
        /// </summary>
        public ZVariable Variable;

        /// <summary>
        /// Expression that is being assigned to the variable.
        /// </summary>
        public IZExpression Expression;

        /// <summary>
        /// Flag indicating if the assignment is a declaration.
        /// </summary>
        public bool IsDeclaration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZAssignment"/> class.
        /// </summary>
        /// <param name="variable">Variable that is being assigned to.</param>
        /// <param name="expression">Expression that is being assigned to the variable.</param>
        /// <param name="isDeclaration">Flag indicating if the assignment is a declaration.</param>
        public ZAssignment(ZVariable variable, IZExpression expression, bool isDeclaration)
        {
            Variable = variable;
            Expression = expression;
            IsDeclaration = isDeclaration;
        }
    }

    /// <summary>
    /// Represents a list.
    /// </summary>
    public class ZList
    {
        /// <summary>
        /// Type of the elements in the list.
        /// </summary>
        public ZType Type;

        /// <summary>
        /// List of expressions that make up the list.
        /// </summary>
        public List<IZExpression> Values;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZList"/> class.
        /// </summary>
        /// <param name="type">Type of the elements in the list.</param>
        /// <param name="values">List of expressions that make up the list.</param>
        public ZList(ZType type, List<IZExpression> values)
        {
            Type = type;
            Values = values;
        }
    }

    // TODO: This might be better as a struct. Also, it might be better to make it more general.
    internal interface IZDeclarationMetaData
    {
        int Line { get; set; }
        int Column { get; set; }
    }
}
