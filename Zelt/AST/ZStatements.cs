using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    /// <summary>
    /// Represents a statement.
    /// </summary>
    public class ZStatement
    {
        /// <summary>
        /// The expression that is the statement.
        /// </summary>
        public IZExpression Expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZStatement"/> class.
        /// </summary>
        /// <param name="expression">The expression that is the statement.</param>
        public ZStatement(IZExpression expression)
        {
            Expression = expression;
        }
    }
}
