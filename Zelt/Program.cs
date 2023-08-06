using Antlr4.Runtime;
using Zelt.Grammar;
using Zelt.Visitors;
using Zelt.Listeners;
using Zelt.AST;
using Zelt.CodeGenerator;

namespace Zelt;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1 || args.Length > 2)
        {
            Console.WriteLine("Usage: Zelt <file> <output>");
            Environment.Exit(1);
        }

        TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);

        // TODO: figure out how to handle multiple files
        // Main file? Specify a main function?

        var fileContents = File.ReadAllText(args[0]);

        // Someday, we'll need to handle multiple files
        string[] sourceCodeLines = File.ReadAllLines(args[0]);

        AntlrInputStream inputStream = new AntlrInputStream(fileContents);
        ZeltLexer lexer = new ZeltLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        ZeltParser parser = new ZeltParser(commonTokenStream);
        parser.AddErrorListener(new ErrorListener());

        // Eventually will need to handle multiple files

        string outputFileName = args.Length > 1 ? args[1] : "output";

        string outputJSFile = outputFileName + ".js";
        string outputHTMLFile = outputFileName + ".html";


        using (StreamWriter htmlStream = new StreamWriter(outputHTMLFile))
        using (StreamWriter jsStream = new StreamWriter(outputJSFile))
        {
            // Get the AST
            ZProgram program = new ProgramVisitor(sourceCodeLines).VisitProgram(parser.program());

            // Generate static HTML
            new HTMLCodeGenerator(htmlStream, outputHTMLFile).GenerateStaticHTML();

            // Generate JavaScript
            new JavaScriptCodeGenerator(jsStream).GenerateCodeForProgram(program);
        }

        TimeOnly endTime = TimeOnly.FromDateTime(DateTime.Now);

        Console.WriteLine("Compiled successfully!");
        Console.WriteLine($"Output files: {outputHTMLFile}, {outputJSFile}");
        Console.WriteLine($"Compilation duration: {endTime - startTime}");
    }
}