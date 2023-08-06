using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zelt.AST;

namespace Zelt.CodeGenerator
{
    public class HTMLCodeGenerator
    {
        public StreamWriter Stream { get; set; }
        public string OutputFilename { get; set; }

        public HTMLCodeGenerator(StreamWriter stream, string outputFilename)
        {
            Stream = stream;
            OutputFilename = outputFilename;
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
                                        <script src="{OutputFilename}.js"></script>
                                    </head>
                                    <body>
                                    </body>
                                """;

            Stream?.WriteLine(htmlOutput);
        }
    }
}
