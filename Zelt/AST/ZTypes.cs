using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public class ZType : IComparable<ZType>
    {
        public string Name;
        public List<ZInterface> Interfaces;
        public bool IsDefined;

        public ZType(string name, List<ZInterface>? interfaces, bool isDefined = false)
        {
            Name = name;
            Interfaces = interfaces ?? new List<ZInterface>();
            IsDefined = isDefined;
        }

        // Primitive types
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
        public static ZType String = new ZType("String", new List<ZInterface>()
        {
            ZInterface.Additive,
            ZInterface.Comparable,
            ZInterface.Equatable,
        }, true);
        public static ZType Bool = new ZType("Bool", new List<ZInterface>()
        {
            ZInterface.Equatable,
            ZInterface.Negatable,
            ZInterface.Logical
        }, true);
        public static ZType Return = new ZType("Return", null, true);
        public static ZType Null = new ZType("Null", null, true);
        public static ZType Any = new ZType("Any", null, true); // Might have to use this for an empty type e.g. a := [] -- would be a := [Any] for now
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

            return -1;
        }

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

    public class ZListType : ZType
    {
        public ZType ElementType;

        public ZListType(ZType? elementType, List<ZInterface>? interfaces = null)
            : base(
                  $"[{elementType?.Name}]", interfaces ?? new List<ZInterface>() { ZInterface.Iterable }, true
            )
        {
            ElementType = elementType ?? ZType.Any;
        }
    }

    public class ZFunctionType : ZType
    {
        public List<ZType> ParameterTypes;

        public List<ZType> ReturnTypes;

        public ZType? CallerType;

        public ZFunctionType(List<ZType> parameterTypes, List<ZType> returnTypes, List<ZInterface>? interfaces = null)
            : base(
                  $"({ListMaker.ToCommaSeparatedList(parameterTypes)}) => {ListMaker.ToCommaSeparatedList(returnTypes)}", interfaces ?? new List<ZInterface>() { ZInterface.Invocable }, true
            )
        {
            ParameterTypes = parameterTypes;
            ReturnTypes = returnTypes;
            CallerType = null;
        }

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

    public static class ListMaker {
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
