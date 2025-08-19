using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace Claude.Orchestrator.Console;

/// <summary>
/// Main program entry point for Claude.Orchestrator console application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main entry point for the Claude.Orchestrator console application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    /// <returns>Exit code.</returns>
    public static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Claude.Orchestrator - Multi-agent workflow orchestration and context management tool")
        {
            // Commands will be added here as we implement features
        };

        var commandLineBuilder = new CommandLineBuilder(rootCommand)
            .UseDefaults()
            .UseExceptionHandler((exception, context) =>
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {exception.Message}");
                System.Console.ResetColor();
                context.ExitCode = 1;
            });

        var parser = commandLineBuilder.Build();
        return await parser.InvokeAsync(args);
    }
}
