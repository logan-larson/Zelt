using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    /// <summary>
    /// Represents the base interface for any expression node in the abstract syntax tree (AST) of Zelt.
    /// </summary>
    public interface IZExpression
    {
        /// <summary>
        /// Gets the data type associated with this expression.
        /// </summary>
        public ZType Type { get; }
    }

    #region Literals

    /// <summary>
    /// Provides a base class for literal expressions in the AST.
    /// </summary>
    /// <typeparam name="T">The underlying data type of the literal value.</typeparam>
    public abstract class ZLiteralExpression<T> : IZExpression
    {
        /// <inheritdoc />
        public ZType Type { get; }

        /// <summary>
        /// Gets the actual value of the literal expression.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZLiteralExpression{T}"/> class with the specified value and type.
        /// </summary>
        /// <param name="value">The actual value of the literal.</param>
        /// <param name="type">The data type of the literal.</param>
        public ZLiteralExpression(T value, ZType type)
        {
            Value = value;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a literal integer expression in the AST.
    /// </summary>
    public class ZIntegerExpression : ZLiteralExpression<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZIntegerExpression"/> class with the specified value.
        /// The type will always be <see cref="ZType.Int" />.
        /// </summary>
        /// <param name="value">The integer value of the literal.</param>
        public ZIntegerExpression(int value) : base(value, ZType.Int) { }
    }

    /// <summary>
    /// Represents a literal float expression in the AST.
    /// </summary>
    public class ZFloatExpression : ZLiteralExpression<float>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZFloatExpression"/> class with the specified value.
        /// The type will always be <see cref="ZType.Float" />.
        /// </summary>
        /// <param name="value"></param>
        public ZFloatExpression(float value) : base(value, ZType.Float) { }
    }

    /// <summary>
    /// Represents a literal string expression in the AST.
    /// </summary>
    public class ZStringExpression : ZLiteralExpression<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZStringExpression"/> class with the specified value.
        /// The type will always be <see cref="ZType.String" />.
        /// </summary>
        /// <param name="value"></param>
        public ZStringExpression(string value) : base(value, ZType.String) { }
    }

    /// <summary>
    /// Represents a literal boolean expression in the AST.
    /// </summary>
    public class ZBoolExpression : ZLiteralExpression<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZBoolExpression"/> class with the specified value.
        /// The type will always be <see cref="ZType.Bool" />.
        /// </summary>
        /// <param name="value"></param>
        public ZBoolExpression(bool value) : base(value, ZType.Bool) { }
    }

    /// <summary>
    /// Represents a literal null expression in the AST.
    /// </summary>
    public class ZNullExpression : ZLiteralExpression<object?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZNullExpression"/> class.
        /// The type will always be <see cref="ZType.Null" />.
        /// </summary>
        public ZNullExpression() : base(null, ZType.Null) { }
    }

    /// <summary>
    /// Represents a literal void expression in the AST.
    /// </summary>
    public class ZVoidExpression : ZLiteralExpression<object?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZVoidExpression"/> class.
        /// The type will always be <see cref="ZType.Void" />.
        /// </summary>
        public ZVoidExpression() : base(null, ZType.Void) { }
    }

    #endregion

    /// <summary>
    /// Represents an identifier expression in the AST. This is used to reference variables, functions, and types.
    /// TODO: Determine all the use cases for identifiers
    /// </summary>
    public class ZIdentifierExpression : IZExpression
    {
        /// <inheritdoc />
        public ZType Type { get; }

        /// <summary>
        /// Gets the name of the identifier.
        /// </summary>
        public string Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZIdentifierExpression"/> class with the specified name and type.
        /// </summary>
        /// <param name="name">The name of the identifier.</param>
        /// <param name="type">The data type associated with the identifier, as resolved by the parser.</param>
        public ZIdentifierExpression(string name, ZType type)
        {
            Name = name;
            Type = type; // type is resolved and passed in by the parser based on the name
        }
    }

    /// <summary>
    /// Represents a function expression in the AST. This captures the definition of a function, including its parameters, return types, and body.
    /// </summary>
    public class ZFunctionExpression : IZExpression
    {
        /// <inheritdoc />
        public ZType Type { get; }

        /// <summary>
        /// Gets the type of the object that's calling the function, if any.
        /// </summary>
        public ZType? Caller;

        /// <summary>
        /// Gets a list of parameter values for the function.
        /// </summary>
        public List<ZParameterValue> ParameterValues;

        /// <summary>
        /// Gets a list of return types for the function.
        /// </summary>
        public List<ZType> ReturnTypes;

        /// <summary>
        /// Gets a list of statements that make up the body of the function.
        /// </summary>
        public List<IZStatement> Body;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZFunctionExpression"/> class with the specified parameters, return types, body, caller, and function type.
        /// </summary>
        /// <param name="parameterValues">List of parameter values for the function.</param>
        /// <param name="returnTypes">List of return types for the function.</param>
        /// <param name="body">List of statements that make up the body of the function.</param>
        /// <param name="caller">The type of the object that's calling the function, if any.</param>
        /// <param name="type">The function's type.</param>
        public ZFunctionExpression(List<ZParameterValue> parameterValues, List<ZType> returnTypes, List<IZStatement> body, ZType? caller, ZType type)
        {
            ParameterValues = parameterValues;
            ReturnTypes = returnTypes;
            Body = body;
            Caller = caller;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a structure (or "struct") expression in the AST. This captures the definition of a struct, including its fields.
    /// </summary>
    public class ZStructExpression : IZExpression
    {
        /// <inheritdoc />
        public ZType Type { get; }

        /// <summary>
        /// Gets a list of declarations inside the struct. These are fields that are declared without being assigned a value.
        /// </summary>
        public List<ZDeclaration> Declarations;

        /// <summary>
        /// Gets a list of assignments inside the struct. These are fields that are declared and assigned a value.
        /// </summary>
        public List<ZAssignment> Assignments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZStructExpression"/> class with the specified declarations, assignments, and struct type.
        /// </summary>
        /// <param name="declarations">List of declarations in the struct.</param>
        /// <param name="assignments">List of assignments in the struct.</param>
        /// <param name="type">The struct's type.</param>
        public ZStructExpression(List<ZDeclaration> declarations, List<ZAssignment> assignments, ZStructType type)
        {
            Declarations = declarations;
            Assignments = assignments;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a struct constructor expression in the AST. This captures the construction of a struct, including its name and arguments.
    /// </summary>
    public class ZStructConstructorExpression : IZExpression
    {
        /// <summary>
        /// The type of the struct being constructed.
        /// </summary>
        public ZType Type { get; }

        /// <summary>
        /// Name of the struct being constructed.
        /// </summary>
        public string Name;

        /// <summary>
        /// List of arguments being passed to the struct constructor.
        /// </summary>
        public List<IZExpression> Arguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZStructConstructorExpression"/> class with the specified name, arguments, and struct type.
        /// </summary>
        /// <param name="name">Name of the struct being constructed.</param>
        /// <param name="arguments">List of arguments being passed to the struct constructor.</param>
        /// <param name="type">The struct's type.</param>
        public ZStructConstructorExpression(string name, List<IZExpression> arguments, ZStructType type)
        {
            Name = name;
            Arguments = arguments;
            Type = type;
        }
    }


    /// <summary>
    /// Represents a caller expression in the AST. This captures the caller of a function, including its type.
    /// </summary>
    public class ZCallerExpression : IZExpression
    {
        /// <summary>
        /// The type of the caller.
        /// </summary>
        public ZType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZCallerExpression"/> class with the specified type.
        /// </summary>
        /// <param name="type">The caller's type.</param>
        public ZCallerExpression(ZType type)
        {
            Type = type;
        }
    }

    /// <summary>
    /// Represents a function call expression in the AST. This captures the call of a function, including its name, arguments, and return types.
    /// </summary>
    public class ZFunctionCallExpression : IZExpression
    {
        /// <summary>
        /// The type of the function call.
        /// </summary>
        public ZType Type { get; }

        /// <summary>
        /// Name of the function being called.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// List of arguments being passed to the function.
        /// </summary>
        public List<IZExpression> Arguments { get; }

        /// <summary>
        /// List of return types for the function.
        /// </summary>
        public List<ZType> ReturnTypes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZFunctionCallExpression"/> class with the specified name, arguments, return types, and function type.
        /// </summary>
        /// <param name="name">Name of the function being called.</param>
        /// <param name="arguments">List of arguments being passed to the function.</param>
        /// <param name="returnTypes">Return types for the function.</param>
        /// <param name="type">The function's type.</param>
        public ZFunctionCallExpression(string name, List<IZExpression> arguments, List<ZType> returnTypes, ZType type)
        {
            Name = name;
            Arguments = arguments;
            ReturnTypes = returnTypes;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a chained expression in the AST. This captures a chain of expressions, including the type of the last expression in the chain.
    /// </summary>
    public class ZChainedExpression : IZExpression
    {
        // The type is the type of the last expression in the chain

        /// <summary>
        /// The type of the chained expression. This is the type of the last expression in the chain.<br />
        /// Either a ZType.Return
        /// <code>
        /// myVector.add(1).add(2) -> ZType.Return
        /// </code>
        /// Or the type of the expression being accessed    
        /// <code>
        /// myVector.add(1).x -> ZType.Int
        /// </code>
        /// </summary>
        public ZType Type { get; }

        /// <summary>
        /// List of expressions in the chain.
        /// </summary>
        public List<IZExpression> Expressions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZChainedExpression"/> class with the specified expressions and type.
        /// </summary>
        /// <param name="expressions">List of expressions in the chain.</param>
        /// <param name="type">The chained expression's type.</param>
        public ZChainedExpression(List<IZExpression> expressions, ZType type)
        {
            Expressions = expressions;
            Type = type;
        }
    }

    /// <summary>
    /// Represents an expression placeholder in the AST. This captures a placeholder expression, including its type.
    /// </summary>
    public class ZExpressionPlaceholder : IZExpression
    {
        /// <summary>
        /// The type of the expression placeholder.
        /// </summary>
        public ZType Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZExpressionPlaceholder"/> class with the specified type.
        /// </summary>
        /// <param name="type">The expression placeholder's type.</param>
        public ZExpressionPlaceholder(ZType type)
        {
            Type = type;
        }
    }

    /// <summary>
    /// Represents a list expression in the AST.
    /// </summary>
    public class ZListExpression : IZExpression
    {
        /// <summary>
        /// The type of the list expression.
        /// </summary>
        public ZType Type { get; }

        /// <summary>
        /// List of expressions in the list.
        /// </summary>
        public List<IZExpression> Elements;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZListExpression"/> class with the specified elements and type.
        /// </summary>
        /// <param name="elements">List of expressions in the list.</param>
        /// <param name="type">The list expression's type.</param>
        public ZListExpression(List<IZExpression> elements, ZType type)
        {
            Elements = elements;
            Type = type;
        }
    }

    /// <summary>
    /// Represents a unary expression in the AST.
    /// </summary>
    public class ZUnaryExpression : IZExpression
    {
        /// <inheritdoc />
        public ZType Type { get; }

        /// <summary>
        /// Gets the expression that's being operated on.
        /// </summary>
        public IZExpression Expression;

        /// <summary>
        /// Gets the operator that's being applied to the expression.
        /// </summary>
        public ZUnaryOperator? Operator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZUnaryExpression"/> class with the specified expression and operator.
        /// </summary>
        /// <param name="expression">The expression that's being operated on.</param>
        /// <param name="operator">The operator that's being applied to the expression.</param>
        public ZUnaryExpression(IZExpression expression, ZUnaryOperator? @operator = null)
        {
            Expression = expression;
            Operator = @operator;
            Type = Expression.Type;
        }
    }

    /// <summary>
    /// Represents a binary expression in the AST.
    /// </summary>
    public class ZBinaryExpression : IZExpression
    {
        /// <inheritdoc />
        public ZType Type { get; }

        /// <summary>
        /// Gets the left-hand side expression of the binary expression.
        /// </summary>
        public IZExpression Left;

        /// <summary>
        /// Gets the right-hand side expression of the binary expression.
        /// </summary>
        public IZExpression Right;

        /// <summary>
        /// Gets the operator that's being applied to the left and right expressions.
        /// </summary>
        public ZBinaryOperator? Operator;

        /* Why did I allow multiple expressions and operators?
        public List<IZExpression> Expressions;
        public List<ZBinaryOperator> Operators;
        */

        /// <summary>
        /// Initializes a new instance of the <see cref="ZBinaryExpression"/> class with the specified left and right expressions and binary operator.
        /// </summary>
        /// <param name="left">The left-hand side expression.</param>
        /// <param name="right">The right-hand side expression.</param>
        /// <param name="operator">The binary operator.</param>
        public ZBinaryExpression(IZExpression left, IZExpression right, ZBinaryOperator? @operator = null)
        {
            Left = left;
            Right = right;
            Operator = @operator;
            Type = Operator?.ReturnType ?? Left.Type;
        }

        /*
        public ZBinaryExpression(List<IZExpression> expressions, List<ZBinaryOperator> operators)
        {
            Expressions = expressions;
            Operators = operators;
            Type = Operators[0].ReturnType;
        }
        */
    }

    /// <summary>
    /// Represents a unary operator in the AST.
    /// </summary>
    public class ZUnaryOperator
    {
        /// <summary>
        /// Gets the actual unary operator symbol or type.
        /// </summary>
        public EZUnaryOperator Operator;

        /// <summary>
        /// Gets the data type that results from applying this unary operator.
        /// </summary>
        public ZType ReturnType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZUnaryOperator"/> class.
        /// </summary>
        /// <param name="operator">The unary operator symbol or type.</param>
        /// <param name="returnType">The resulting data type of the unary operation.</param>
        public ZUnaryOperator(EZUnaryOperator @operator, ZType returnType)
        {
            Operator = @operator;
            ReturnType = returnType;
        }
    }

    /// <summary>
    /// Represents a binary operator in the AST.
    /// </summary>
    public class ZBinaryOperator
    {
        /// <summary>
        /// Gets the actual binary operator symbol or type.
        /// </summary>
        public EZBinaryOperator Operator;
        
        /// <summary>
        /// Gets the data type that results from applying this binary operator.
        /// </summary>
        public ZType ReturnType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZBinaryOperator"/> class.
        /// </summary>
        /// <param name="operator">The binary operator symbol or type.</param>
        /// <param name="returnType">The resulting data type of the binary operation.</param>
        public ZBinaryOperator(EZBinaryOperator @operator, ZType returnType)
        {
            Operator = @operator;
            ReturnType = returnType;
        }
    }

    /// <summary>
    /// Represents unary operators supported in the language.
    /// </summary>
    public enum EZUnaryOperator
    {
        /// <summary>
        /// Represents the negation operator.
        /// This operator inverts the sign of the operand.
        /// Example:
        /// <code>
        /// a : Int = 5;
        /// b : Int = -a; // b is -5
        /// </code>
        /// </summary>
        Negate
    }

    /// <summary>
    /// Represents binary operators supported in the language.
    /// </summary>
    public enum EZBinaryOperator
    {
        /// <summary>
        /// Represents the multiplication (*) operator.
        /// Example:
        /// <code>
        /// product : Int = 3 * 4; // product is 12
        /// </code>
        /// </summary>
        Multiply,

        /// <summary>
        /// Represents the division (/) operator.
        /// Example:
        /// <code>
        /// quotient : Int = 12 / 4; // quotient is 3
        /// </code>
        /// </summary>
        Divide,


        /// <summary>
        /// Represents the addition (+) operator.
        /// Example:
        /// <code>
        /// sum : Int = 3 + 4; // sum is 7
        /// </code>
        /// </summary>
        Add,

        /// <summary>
        /// Represents the subtraction (-) operator.
        /// Example:
        /// <code>
        /// difference : Int = 12 - 4; // difference is 8
        /// </code>
        /// </summary>
        Subtract,

        /// <summary>
        /// Represents the modulation (%) operator.
        /// Example:
        /// <code>
        /// remainder : Int = 12 % 5; // remainder is 2
        /// </code>
        /// </summary>
        Modulo,

        /// <summary>
        /// Represents the equality (==) operator.
        /// Example:
        /// <code>
        /// isEqual : Bool = 4 == 4; // isEqual is true
        /// </code>
        /// </summary>
        Equal,

        /// <summary>
        /// Represents the inequality (!=) operator.
        /// Example:
        /// <code>
        /// isNotEqual : Bool = 11 != 10; // isNotEqual is true
        /// </code>
        /// </summary>
        NotEqual,

        /// <summary>
        /// Represents the greater than (&gt;) operator.
        /// Example:
        /// <code>
        /// isGreater : Bool = 11 &gt; 10; // isGreater is true
        /// </code>
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Represents the greater than or equal to (&gt;=) operator.
        /// Example:
        /// <code>
        /// isGreaterOrEqual : Bool = 11 >= 11; // isGreaterOrEqual is true
        /// </code>
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// Represents the less than (&lt;) operator.
        /// Example:
        /// <code>
        /// isLess : Bool = 7 &lt; 10; // isLess is true
        /// </code>
        /// </summary>
        LessThan,

        /// <summary>
        /// Represents the less than or equal to (&lt;=) operator.
        /// Example:
        /// <code>
        /// isLessOrEqual : Bool = 11 &lt;= 11; // isLessOrEqual is true
        /// </code>
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// Represents the logical AND (&amp;&amp;) operator.
        /// Example:
        /// <code>
        /// isTrue : Bool = true &amp;&amp; true; // isTrue is true
        /// isFalse : Bool = true &amp;&amp; false; // isFalse is false
        /// </code>
        /// </summary>
        And,

        /// <summary>
        /// Represents the logical OR (||) operator.
        /// Example:
        /// <code>
        /// isTrue : Bool = true || false; // isTrue is true
        /// isFalse : Bool = false || false; // isFalse is false
        /// </code>
        /// </summary>
        Or
    }
}
