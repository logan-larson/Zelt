using Antlr4.Runtime;
using Zelt.Grammar;
using Zelt.Visitors;
using Zelt.Listeners;

namespace Zelt;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1 || args.Length > 2)
        {
            Console.WriteLine("Usage: Zelt [REPL | <file>] <output>");
            Environment.Exit(1);
        }

        if (args[0] == "REPL")
        {
            ExecuteREPL();
        }
        else
        {
            CompileFiles(args);
        }
    }

    static void ExecuteREPL()
    {
        var visitor = new Visitor();

        Console.WriteLine("Welcome to the Zelt REPL");
        Console.WriteLine("'quit()' to stop REPL");

        while (true)
        {
            // TODO: figure out how to handle multiple lines
            // Shift+Tab??

            Console.Write("> ");
            var line = Console.ReadLine();

            AntlrInputStream inputStream = new AntlrInputStream(line);
            ZeltLexer lexer = new ZeltLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            ZeltParser parser = new ZeltParser(commonTokenStream);
            parser.AddErrorListener(new ErrorListener());
            visitor.Visit(parser.statement());
        }
    }

    static void CompileFiles(string[] args)
    {
        // TODO: figure out how to handle multiple files
        // Main file? Specify a main function?

        var fileContents = File.ReadAllText(args[0]);

        AntlrInputStream inputStream = new AntlrInputStream(fileContents);
        ZeltLexer lexer = new ZeltLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        ZeltParser parser = new ZeltParser(commonTokenStream);
        parser.AddErrorListener(new ErrorListener());

        // Eventually will need to handle multiple files

        string outputFileName = args.Length > 1 ? args[1] : "output";

        string outputJSFilePath = outputFileName + ".js";
        string outputHTMLFilePath = outputFileName + ".html";

        // Write the HTML file, this will be static for now
        // If we allow the user to access members of the DOM then it will need to be dynamic
        {
        }

        using (StreamWriter htmlStream = new StreamWriter(outputHTMLFilePath))
        using (StreamWriter jsStream = new StreamWriter(outputJSFilePath))
        {
            var visitor = new Visitor(htmlStream, jsStream, outputFileName);

            // Generate static HTML
            visitor.GenerateStaticHTML();

            // Write output while parsing
            visitor.Visit(parser.program());

            // Type-checking
            visitor.CheckVariableDeclarationTypes();
        }
    }
}