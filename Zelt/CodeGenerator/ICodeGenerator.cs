using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;

namespace Zelt.CodeGenerator
{
    /// <summary>
    /// Provides a contract for code generators.
    /// </summary>
    public interface ICodeGenerator
    {
        /// <summary>
        /// The stream to write the code to.
        /// </summary>
        StreamWriter Stream { get; set; }

        /// <summary>
        /// Generates code for a program.
        /// </summary>
        /// <param name="ast">The root AST node of the program.</param>
        void GenerateCodeForProgram(ZProgram ast);

        /// <summary>
        /// Generates code for a statement.
        /// </summary>
        /// <param name="statement">The statement to generate code for.</param>
        void GenerateCodeForStatement(ZStatement statement);

        /// <summary>
        /// Generates code for an expression.
        /// </summary>
        /// <param name="expression">The expression to generate code for.</param>
        void GenerateCodeForExpression(IZExpression expression);

        /// <summary>
        /// Generates code for a declaration.
        /// </summary>
        /// <param name="declarations">The declarations to generate code for.</param>
        /// <param name="hasAssignment">Flag indicating whether the declaration has an assignment.</param>
        void GenerateCodeForDeclaration(List<ZDeclaration> declarations, bool hasAssignment);

        /// <summary>
        /// Generates code for an assignment.
        /// </summary>
        /// <param name="assignments">The assignments to generate code for.</param>
        /// <param name="isDeclaration">Flag indicating whether the assignment is a declaration.</param>
        void GenerateCodeForAssignment(List<ZAssignment> assignments, bool isDeclaration);

        /// <summary>
        /// Generates code for an identifier.
        /// </summary>
        /// <param name="identifier">The identifier to generate code for.</param>
        void GenerateCodeForIdentifier(ZIdentifierExpression identifier);

        /*
        void GenerateCodeForList(ZListExpression list);

        void GenerateCodeForFunctionDeclaration(ZFunctionDecalaration functionDecalaration);

        void GenerateCodeForFunction(ZFunctionExpression function);

        void GenerateCodeForStructDeclaration(ZStructDeclaration structDeclaration);

        void GenerateCodeForStructInstance(ZStructInstance structInstance);
        */
    }
}
