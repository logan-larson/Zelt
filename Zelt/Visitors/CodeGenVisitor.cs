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
        public StreamWriter HTMLStream { get; private set; }

        // Maybe JSStreams should be a list of streams, so we can have multiple files?
        public StreamWriter JSStream { get; private set; }

        public string OutputFileName;

        public Visitor(StreamWriter htmlStream, StreamWriter jsStream, string outputFileName)
        {
            HTMLStream = htmlStream;
            JSStream = jsStream;
            OutputFileName = outputFileName;
        }

        public void GenerateStaticHTML()
        {
            // Static HTML generation
            string htmlOutput = $"""
                                    <!DOCTYPE html>
                                    <html lang="en">
                                    <head>
                                        <meta charset=""UTF-8"">
                                        <title>Zelt Runtime LOL</title>
                                        <script src="{OutputFileName}.js"></script>
                                    </head>
                                    <body>
                                    </body>
                                """;

            HTMLStream.WriteLine(htmlOutput);
        }

        private void WriteMain()
        {
            JSStream.WriteLine("window.onload = function() {");

            // Main body

            JSStream.WriteLine("};");
        }
    }
}
