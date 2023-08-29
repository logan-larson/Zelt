using Antlr4.Runtime;
using Zelt.Grammar;
using Zelt.Visitors;
using Zelt.Listeners;
using Zelt.AST;
using Zelt.CodeGenerator;
using System.CommandLine;

namespace Zelt;

class Program
{
    static int Main(string[] args)
    {
        var outputOption = new Option<string>(
                aliases: new [] {"-o", "--output"},
                description: "Output file name.",
                getDefaultValue: () => "output");

        var verboseOption = new Option<bool>(
                aliases: new [] {"-v", "--verbose"},
                description: "");

        var inputFilesArgument = new Argument<string[]>(
                name: "inputFiles",
                description: "Input files to compile.");

        var createCommand = new Command("create", "Create a new Zelt project.")
        {
        };

        createCommand.SetHandler(new Action(CreateHandler));

        var buildCommand = new Command("build", "Build your Zelt project for production.")
        {
            inputFilesArgument,
            outputOption,
            verboseOption,
        };

        buildCommand.SetHandler(
                new Action<string[], string, bool>(BuildHandler), 
                inputFilesArgument, outputOption, verboseOption
        );

        var runCommand = new Command("run", "Run your Zelt project for development.")
        {
            inputFilesArgument,
            outputOption,
            verboseOption
        };

        runCommand.SetHandler(
                new Action<string[], string, bool>(RunHandler), 
                inputFilesArgument, outputOption, verboseOption
        );

        var packageCommand = new Command("package", "Zelt's package manager.")
        {
        };

        packageCommand.SetHandler(new Action(PackageHandler));

        var rootCommand = new RootCommand("Zelt CLI");

        rootCommand.AddCommand(createCommand);
        rootCommand.AddCommand(buildCommand);
        rootCommand.AddCommand(runCommand);
        rootCommand.AddCommand(packageCommand);

        return rootCommand.InvokeAsync(args).Result;
    }


    public static void CreateHandler() { }

    public static void BuildHandler(string[] inputFiles, string outputFilename, bool verbose)
    {
        Execute(inputFiles, outputFilename, verbose);
    }

    public static void RunHandler(string[] inputFiles, string outputFilename, bool verbose)
    {
        Execute(inputFiles, outputFilename, verbose);
    }

    public static void PackageHandler() { }


    public static void Execute(string[] inputFilenames, string outputFilename, bool verbose)
    {
        TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);
        TimeOnly beginStepTime = TimeOnly.FromDateTime(DateTime.Now);
        TimeSpan readInputTime;
        TimeSpan lexerTime;
        TimeSpan parserTime;
        TimeSpan astBuildTime;
        TimeSpan codeGenTime;

        if (verbose && inputFilenames.Length > 0)
        {
            Console.WriteLine("Input files:");
            foreach (var inputFilename in inputFilenames)
            {
                Console.WriteLine($"- {inputFilename}");
            }
            Console.WriteLine();
        }

        var fileContents = File.ReadAllText(inputFilenames[0]);
        
        // Someday, we'll need to handle multiple files
        string[] sourceCodeLines = File.ReadAllLines(inputFilenames[0]);

        readInputTime = TimeOnly.FromDateTime(DateTime.Now) - beginStepTime;
        beginStepTime = TimeOnly.FromDateTime(DateTime.Now);

        AntlrInputStream inputStream = new AntlrInputStream(fileContents);
        ZeltLexer lexer = new ZeltLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);

        lexerTime = TimeOnly.FromDateTime(DateTime.Now) - beginStepTime; 
        beginStepTime = TimeOnly.FromDateTime(DateTime.Now);

        ZeltParser parser = new ZeltParser(commonTokenStream);
        parser.AddErrorListener(new ErrorListener());

        parserTime = TimeOnly.FromDateTime(DateTime.Now) - beginStepTime;
        beginStepTime = TimeOnly.FromDateTime(DateTime.Now);

        // Eventually will need to handle multiple files

        //string outputFileName = args.Length > 1 ? args[1] : "output";

        string outputJSFile = outputFilename + ".js";
        string outputHTMLFile = outputFilename + ".html";


        using (StreamWriter htmlStream = new StreamWriter(outputHTMLFile))
        using (StreamWriter jsStream = new StreamWriter(outputJSFile))
        {
            // Get the AST
            ZProgram program = new ProgramVisitor(sourceCodeLines).VisitProgram(parser.program());

            astBuildTime  = TimeOnly.FromDateTime(DateTime.Now) - beginStepTime;
            beginStepTime = TimeOnly.FromDateTime(DateTime.Now);

            // Generate static HTML
            new HTMLCodeGenerator(htmlStream, outputHTMLFile).GenerateStaticHTML();

            // Generate JavaScript
            new JavaScriptCodeGenerator(jsStream).GenerateCodeForProgram(program);

            codeGenTime = TimeOnly.FromDateTime(DateTime.Now) - beginStepTime;
            beginStepTime = TimeOnly.FromDateTime(DateTime.Now);
        }

        TimeOnly endTime = TimeOnly.FromDateTime(DateTime.Now);

        Console.WriteLine("Compiled successfully!");
        Console.WriteLine($"Output files: {outputHTMLFile}, {outputJSFile}");

        // User specified --show-
        if (verbose)
        {
            Console.WriteLine("Compilation step times:");
            Console.WriteLine($"- Read files duration: {readInputTime}");
            Console.WriteLine($"- Lexer duration: {lexerTime}");
            Console.WriteLine($"- Parser duration: {parserTime}");
            Console.WriteLine($"- AST building duration: {astBuildTime}");
            Console.WriteLine($"- Code generation duration: {codeGenTime}");
        }

        Console.WriteLine($"Overall compilation duration: {endTime - startTime}");



    }
}
