using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    /// <summary>
    /// Represents a custom type in Zelt.
    /// </summary>
    public class ZType : IComparable<ZType>
    {
        /// <summary>
        /// The name of the type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The interfaces that the type implements.
        /// </summary>
        public List<ZInterface> Interfaces { get; set; }

        /// <summary>
        /// A flag that indicates whether the type has been defined.
        /// </summary>
        public bool IsDefined { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZType"/> class.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <param name="interfaces">The interfaces implemented by the type.</param>
        /// <param name="isDefined">Flag indicating if the type is defined.</param>
        public ZType(string name, List<ZInterface>? interfaces, bool isDefined = false)
        {
            Name = name;
            Interfaces = interfaces ?? new List<ZInterface>();
            IsDefined = isDefined;
        }

        #region Built-in Types

        /// <summary>
        /// Represents the <see cref="Int"/> type in Zelt.
        /// </summary>
        public static ZType Int = new ZType("Int", new List<ZInterface>()
        {
            ZInterface.Multiplicative,
            ZInterface.Divisive,
            ZInterface.Modulable,
            ZInterface.Additive,
            ZInterface.Subtractive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);

        /// <summary>
        /// Represents the <see cref="Float"/> type in Zelt.
        /// </summary>
        public static ZType Float = new ZType("Float", new List<ZInterface>()
        {
            ZInterface.Multiplicative,
            ZInterface.Divisive,
            ZInterface.Modulable,
            ZInterface.Additive,
            ZInterface.Subtractive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);

        /// <summary>
        /// Represents the <see cref="Char"/> type in Zelt.
        /// </summary>
        public static ZType Char = new ZType("Char", new List<ZInterface>()
        {
            ZInterface.Additive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);

        /// <summary>
        /// Represents the <see cref="String"/> type in Zelt.
        /// Might change this to a list of chars
        /// </summary>
        public static ZType String = new ZType("String", new List<ZInterface>()
        {
            ZInterface.Additive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);

        /// <summary>
        /// Represents the <see cref="Bool"/> type in Zelt.
        /// </summary>
        public static ZType Bool = new ZType("Bool", new List<ZInterface>()
        {
            ZInterface.Equatable,
            ZInterface.Negatable,
            ZInterface.Logical
        }, true);

        /// <summary>
        /// Represents the <see cref="Return"/> type in Zelt.
        /// </summary>
        public static ZType Return = new ZType("Return", null, true);

        /// <summary>
        /// Represents the <see cref="FunctionCall"/> type in Zelt.
        /// </summary>
        public static ZType FunctionCall = new ZType("FunctionCall", null, true);

        /// <summary>
        /// Represents the <see cref="Struct"/> type in Zelt.
        /// </summary>
        public static ZType Struct = new ZType("Struct", null, true);

        /// <summary>
        /// Represents the <see cref="Null"/> type in Zelt.
        /// </summary>
        public static ZType Null = new ZType("Null", null, true);

        /// <summary>
        /// Represents the <see cref="Void"/> type in Zelt.
        /// </summary>
        public static ZType Void = new ZType("Void", null, true);

        /// <summary>
        /// Represents the <see cref="Any"/> type in Zelt.
        /// This might be the basis for generics
        /// </summary>
        public static ZType Any = new ZType("Any", null, true); // Might have to use this for an empty type e.g. a := [] -- would be a := [Any] for now

        #endregion

        /// <summary>
        /// Compares the current ZType to another ZType.
        /// </summary>
        /// <param name="other">The other ZType to compare with.</param>
        /// <returns>0 if the types are equal, -1 otherwise.</returns>
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

            return -1;
        }

        /// <summary>
        /// Checks if the current ZType implements the given interface, either directly or through inheritance.
        /// </summary>
        /// <param name="other">The interface to check against.</param>
        /// <returns>True if the type implements the interface, false otherwise.</returns>
        public bool Implements(ZInterface other)
        {
            // If the type implements the interface directly
            foreach (var @interface in Interfaces)
            {
                if (@interface.CompareTo(other) != 0)
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

    /// <summary>
    /// Represents a list type in Zelt.
    /// </summary>
    public class ZListType : ZType
    {
        /// <summary>
        /// The type of the elements in the list.
        /// </summary>
        public ZType ElementType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZListType"/> class.
        /// </summary>
        /// <param name="elementType">The type of elemments in the list.</param>
        /// <param name="interfaces">The interfaces implemented by the list type.</param>
        public ZListType(ZType? elementType, List<ZInterface>? interfaces = null)
            : base(
                  $"[{elementType?.Name}]", interfaces ?? new List<ZInterface>() { ZInterface.Iterable }, true
            )
        {
            ElementType = elementType ?? ZType.Any;
        }
    }

    /// <summary>
    /// Represents a function type in Zelt.
    /// </summary>
    public class ZFunctionType : ZType
    {
        /// <summary>
        /// A list of parameter types for the function.
        /// </summary>
        public List<ZType> ParameterTypes;

        /// <summary>
        /// A list of return types for the function.
        /// </summary>
        public List<ZType> ReturnTypes;

        /// <summary>
        /// The type of the caller of the function, if any.
        /// </summary>
        public ZType? CallerType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZFunctionType"/> class.
        /// </summary>
        /// <param name="parameterTypes">The parameter types for the function.</param>
        /// <param name="returnTypes">The return types for the function.</param>
        /// <param name="interfaces">The interfaces implemented by the function type.</param>
        public ZFunctionType(List<ZType> parameterTypes, List<ZType> returnTypes, List<ZInterface>? interfaces = null)
            : base(
                  $"({ListMaker.ToCommaSeparatedList(parameterTypes)}) => {ListMaker.ToCommaSeparatedList(returnTypes)}", interfaces ?? new List<ZInterface>() { ZInterface.Invocable }, true
            )
        {
            ParameterTypes = parameterTypes;
            ReturnTypes = returnTypes;
            CallerType = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZFunctionType"/> class.
        /// </summary>
        /// <param name="parameterTypes">The parameter types for the function.</param>
        /// <param name="returnTypes">The return types for the function.</param>
        /// <param name="callerType">The type of the caller of the function.</param>
        /// <param name="interfaces">The interfaces implemented by the function type.</param>
        public ZFunctionType(List<ZType> parameterTypes, List<ZType> returnTypes, ZType callerType, List<ZInterface>? interfaces = null)
            : base(
                  $"{callerType.Name} ({ListMaker.ToCommaSeparatedList(parameterTypes)}) => {ListMaker.ToCommaSeparatedList(returnTypes)}", interfaces ?? new List<ZInterface>() { ZInterface.Invocable }, true
            )
        {
            ParameterTypes = parameterTypes;
            ReturnTypes = returnTypes;
            CallerType = callerType;
        }
    }

    /// <summary>
    /// Represents a struct type in Zelt.
    /// </summary>
    public class ZStructType : ZType
    {
        /// <summary>
        /// A list of types for the fields of the struct.
        /// </summary>
        public List<ZType> MemberTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZStructType"/> class.
        /// </summary>
        /// <param name="memberTypes">A list of types for the fields struct.</param>
        public ZStructType(List<ZType> memberTypes)
            : base($"Struct({ListMaker.ToCommaSeparatedList(memberTypes)})", null, true)
        {
            MemberTypes = memberTypes;
        }
    }

    internal static class ListMaker {
        public static string ToCommaSeparatedList(List<ZType> types)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < types.Count; i++)
            {
                sb.Append(types[i].Name);
                if (i != types.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }
    }
}
