using Antlr4.Runtime;
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

        public ZFunctionExpression(List<ZParameterValue> parameterValues, List<ZType> returnTypes, List<IZStatement> body, ZType? caller, ZType type)
        {
            ParameterValues = parameterValues;
            ReturnTypes = returnTypes;
            Body = body;
            Caller = caller;
            Type = type;
        }
    }

    public class ZStructExpression : IZExpression
    {
        public ZType Type { get; }

        public List<ZDeclaration> Declarations;
        public List<ZAssignment> Assignments;

        public ZStructExpression(List<ZDeclaration> declarations, List<ZAssignment> assignments, ZStructType type)
        {
            Declarations = declarations;
            Assignments = assignments;
            Type = type;
        }
    }

    public class ZStructConstructorExpression : IZExpression
    {
        public ZType Type { get; }

        public string Name;

        public List<IZExpression> Arguments;

        public ZStructConstructorExpression(string name, List<IZExpression> arguments, ZStructType type)
        {
            Name = name;
            Arguments = arguments;
            Type = type;
        }
    }


    public class ZCallerExpression : IZExpression
    {
        public ZType Type { get; }

        public ZCallerExpression(ZType type)
        {
            Type = type;
        }
    }

    public class ZFunctionCallExpression : IZExpression
    {
        public ZType Type { get; }
        public string Name { get; }
        public List<IZExpression> Arguments { get; }
        public List<ZType> ReturnTypes { get; }

        public ZFunctionCallExpression(string name, List<IZExpression> arguments, List<ZType> returnTypes, ZType type)
        {
            Name = name;
            Arguments = arguments;
            ReturnTypes = returnTypes;
            Type = type;
        }
    }

    public class ZChainedExpression : IZExpression
    {
        // The type is the type of the last expression in the chain
        // Either a ZType.Return -- myVector.add(1).add(2) -> ZType.Return
        // Or the type of the expression being accessed -- myVector.add(1).x -> ZType.Int
        public ZType Type { get; }

        public List<IZExpression> Expressions;

        public ZChainedExpression(List<IZExpression> expressions, ZType type)
        {
            Expressions = expressions;
            Type = type;
        }
    }

    public class ZExpressionPlaceholder : IZExpression
    {
        public ZType Type { get; }

        public ZExpressionPlaceholder(ZType type)
        {
            Type = type;
        }
    }

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
        public ZUnaryOperator? Operator;

        public ZUnaryExpression(IZExpression expression, ZUnaryOperator? @operator = null)
        {
            Expression = expression;
            Operator = @operator;
            Type = Expression.Type;
        }
    }

    public class ZBinaryExpression : IZExpression
    {
        public ZType Type { get; }

        public List<IZExpression> Expressions;

        public List<ZBinaryOperator> Operators;

        public ZBinaryExpression(List<IZExpression> expressions, List<ZBinaryOperator> operators)
        {
            Expressions = expressions;
            Operators = operators;
            Type = Operators[0].ReturnType;
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
