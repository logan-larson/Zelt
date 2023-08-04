using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Zelt.Grammar;
using Zelt.CompilerHelpers;
using Antlr4.Runtime.Tree;

namespace Zelt.Visitors
{
    public partial class Visitor : ZeltParserBaseVisitor<object>
    {
        public void WriteOutputFile(string outputFileName)
        {
            string outputJSFilePath;
            string outputHTMLFilePath;
            if (outputFileName == null)
            {
                outputFileName = "output";
                outputJSFilePath = outputFileName + ".js";
                outputHTMLFilePath = outputFileName + ".html";
            }
            else
            {
                outputJSFilePath = outputFileName + ".js";
                outputHTMLFilePath = outputFileName + ".html";
            }

            using (StreamWriter outputFile = new StreamWriter(outputHTMLFilePath))
            {
                string htmlOutput = $"""
                                        <!DOCTYPE html>
                                        <html lang="en">
                                        <head>
                                            <meta charset=""UTF-8"">
                                            <title>Zelt Runtime LOL</title>
                                            <script src="{outputFileName}.js"></script>
                                        </head>
                                        <body>
                                        </body>
                                    """;
                outputFile.WriteLine(htmlOutput);
            }

            using (StreamWriter outputFile = new StreamWriter(outputJSFilePath))
            {
                outputFile.WriteLine("// Zelt -> JavaScript");

                WriteVariables(outputFile);

                WriteMain(outputFile);
            }
        }

        private void WriteVariables(StreamWriter outputFile)
        {
            foreach (var variable in Variables)
            {
                outputFile.WriteLine($"\tvar {variable.Value.name} = '';");
            }
        }

        private void WriteMain(StreamWriter outputFile)
        {
            outputFile.WriteLine("window.onload = function() {");

            outputFile.WriteLine("};");
        }
    }
}
