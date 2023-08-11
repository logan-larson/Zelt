using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public interface IZExpression
    {
        public ZType Type { get; }
    }

    // Literals

    public abstract class ZLiteralExpression<T> : IZExpression
    {
        public ZType Type { get; }
        public T Value { get; }

        public ZLiteralExpression(T value, ZType type)
        {
            Value = value;
            Type = type;
        }
    }

    public class ZIntegerExpression : ZLiteralExpression<int>
    {
        public ZIntegerExpression(int value) : base(value, ZType.Int) { }
    }

    public class ZFloatExpression : ZLiteralExpression<float>
    {
        public ZFloatExpression(float value) : base(value, ZType.Float) { }
    }

    public class ZStringExpression : ZLiteralExpression<string>
    {
        public ZStringExpression(string value) : base(value, ZType.String) { }
    }

    public class ZBoolExpression : ZLiteralExpression<bool>
    {
        public ZBoolExpression(bool value) : base(value, ZType.Bool) { }
    }

    public class ZNullExpression : ZLiteralExpression<object?>
    {
        public ZNullExpression() : base(null, ZType.Null) { }
    }

    // Identifier

    public class ZIdentifierExpression : IZExpression
    {
        public ZType Type { get; }

        public string Name;

        public ZIdentifierExpression(string name, ZType type)
        {
            Name = name;
            Type = type; // type is resolved and passed in by the parser based on the name
        }
    }


    public class ZFunctionExpression : IZExpression
    {
        public ZType Type { get; }

        public ZType? Caller;
        public List<ZParameterValue> ParameterValues;
        public List<ZType> ReturnTypes;
        public List<IZStatement> Body;

        /*
        public ZFunctionExpression(List<ZParameterValue> parameterValues, List<ZType> returnTypes, List<IZStatement> body, ZType type)
        {
            ParameterValues = parameterValues;
            ReturnTypes = returnTypes;
            Body = body;
            Caller = null;
            Type = type;
        }
        */

        public ZFunctionExpression(List<ZParameterValue> parameterValues, List<ZType> returnTypes, List<IZStatement> body, ZType? caller, ZType type)
        {
            ParameterValues = parameterValues;
            ReturnTypes = returnTypes;
            Body = body;
            Caller = caller;
            Type = type;
        }
    }


    /*
    public class ZFunctionExpression : IZExpression
    {
        // Type
        public ZType Type { get; }

        // Parameters -- Are these assignments or declarations?
        // (x : Int, y : Int) => { x + y }      --- parameters as declarations
        // (x := 1, y := 2) => Int { x + y }    --- parameters as assignments, when you allow default values
        public List<ZDeclaration> Parameters;

        // Return types
        public List<ZType> ReturnTypes;

        // Body
        public List<IZStatement> Body;

        // Caller type -- null if no caller type is specified
        public ZType? CallerType;

        public ZFunctionExpression(ZType type, List<ZDeclaration> parameters, List<ZType> returnTypes, List<IZStatement> body, ZType? callerType)
        {
            Type = type;
            Parameters = parameters;
            ReturnTypes = returnTypes;
            Body = body;
            CallerType = callerType;
        }

    }
    */

    public class ZListExpression : IZExpression
    {
        public ZType Type { get; }

        public List<IZExpression> Elements;

        public ZListExpression(List<IZExpression> elements, ZType type)
        {
            Elements = elements;
            Type = type;
        }
    }

    public class ZUnaryExpression : IZExpression
    {
        public ZType Type { get; }

        public IZExpression Expression;
        public ZUnaryOperator Operator;

        public ZUnaryExpression(IZExpression expression, ZUnaryOperator @operator)
        {
            Expression = expression;
            Operator = @operator;
            Type = Operator.ReturnType;
        }
    }

    public class ZBinaryExpression : IZExpression
    {
        public ZType Type { get; }

        public IZExpression Left;
        public IZExpression Right;
        public ZBinaryOperator Operator;

        public ZBinaryExpression(IZExpression left, IZExpression right, ZBinaryOperator @operator)
        {
            Left = left;
            Right = right;
            Operator = @operator;
            Type = Operator.ReturnType;
        }
    }

    public class ZUnaryOperator
    {
        public EZUnaryOperator Operator;
        public ZType ReturnType;

        public ZUnaryOperator(EZUnaryOperator @operator, ZType returnType)
        {
            Operator = @operator;
            ReturnType = returnType;
        }
    }

    public class ZBinaryOperator
    {
        public EZBinaryOperator Operator;
        public ZType ReturnType;

        public ZBinaryOperator(EZBinaryOperator @operator, ZType returnType)
        {
            Operator = @operator;
            ReturnType = returnType;
        }
    }

    public enum EZUnaryOperator
    {
        Negate
    }

    public enum EZBinaryOperator
    {
        Multiply,
        Divide,
        Add,
        Subtract,
        Modulo,
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        And,
        Or
    }
}
