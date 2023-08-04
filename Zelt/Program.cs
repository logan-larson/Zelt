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
            InterpretFiles(args);
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

    static void InterpretFiles(string[] args)
    {
        // TODO: figure out how to handle multiple files
        // Main file? Specify a main function?
        var tokens = false;

        var fileContents = File.ReadAllText(args[0]);

        AntlrInputStream inputStream = new AntlrInputStream(fileContents);
        ZeltLexer lexer = new ZeltLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);

        if (tokens)
        {
            commonTokenStream.Fill();

            foreach (var token in commonTokenStream.GetTokens())
            {
                Console.WriteLine(token);
            }
        }
        else
        {
            ZeltParser parser = new ZeltParser(commonTokenStream);
            parser.AddErrorListener(new ErrorListener());
            var visitor = new Visitor();

            // AST traversal
            visitor.Visit(parser.program());

            // Type-checking
            visitor.CheckVariableDeclarationTypes();

            // Code generation
            if (args.Length > 1)
            {
                visitor.WriteOutputFile(args[1]);
            }
            else
            {
                visitor.WriteOutputFile("out");
            }
        }
    }
}