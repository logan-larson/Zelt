using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    // -- Statements --

    public interface IZStatement { }

    /*
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
    */

    /// <summary>
    /// Represents a statement that is just an expression.
    /// </summary>
    public class ZExpressionStatement : IZStatement
    {
        /// <summary>
        /// The expression that is the statement.
        /// </summary>
        public IZExpression Expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZExpressionStatement"/> class.
        /// </summary>
        /// <param name="expression">The expression that is the statement.</param>
        public ZExpressionStatement(IZExpression expression)
        {
            Expression = expression;
        }
    }

    /*
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
    */
}
