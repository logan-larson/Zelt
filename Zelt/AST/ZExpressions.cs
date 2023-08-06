using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public class ZExpressionList
    {
        public List<IZExpression> Expressions;

        public ZExpressionList()
        {
            Expressions = new List<IZExpression>();
        }
    }

    public interface IZExpression
    {
        public ZType Type { get; }
    }

    public class ZLiteralExpression : IZExpression
    {
        public ZType Type { get; }
        
        public ZValue Value;

        public ZLiteralExpression(ZValue value)
        {
            Value = value;
            Type = value.Type;
        }
    }

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
