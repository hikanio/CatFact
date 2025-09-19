using System.CommandLine;
using CatFact.Repositories;
using CatFact.Services;

namespace CatFact.CLI;

public static class CatFactsCliCommands
{
    public static RootCommand CreateRootCommand(ICatFactService catFactService, ICatFactRepository catFactRepository)
    {
        var rootCommand = new RootCommand("Cat Facts CLI");
        
        var addCommand = CreateAddCommand(catFactService, catFactRepository);
        var listCommand = CreateListCommand(catFactRepository);
        var pathCommand = CreatePathCommand(catFactRepository);
        
        rootCommand.Subcommands.Add(addCommand);
        rootCommand.Subcommands.Add(listCommand);
        rootCommand.Subcommands.Add(pathCommand);
        
        return rootCommand;
    }

    private static Command CreateAddCommand(ICatFactService catFactService, ICatFactRepository catFactRepository)
    {
        var addCommand = new Command("add", "Fetches and saves a random cat fact");
        addCommand.SetAction(async parseResult =>
        {
            var fact = await catFactService.GetCatFactAsync();
            if (fact == null)
            {
                Console.WriteLine("Failed to fetch a cat fact.");
                return;
            }
            Console.WriteLine(fact.Fact);

            catFactRepository.Save(fact);
        });
        
        return addCommand;
    }

    private static Command CreateListCommand(ICatFactRepository catFactRepository)
    {
        var listCommand = new Command("list", "Displays saved cat facts");
        listCommand.SetAction(parseResult =>
        {
            var allFacts = catFactRepository.GetAll();
            Console.WriteLine("Cat facts:");
            foreach (var savedFact in allFacts)
            {
                Console.WriteLine($"- {savedFact.Fact} (Length: {savedFact.Length})");
            }
        });
        
        return listCommand;
    }

    private static Command CreatePathCommand(ICatFactRepository catFactRepository)
    {
        var pathCommand = new Command("path", "Displays the path to the file where cat facts are saved");
        pathCommand.SetAction(parseResult =>
        {
            var filePath = catFactRepository.GetFilePath();
            Console.WriteLine($"Cat facts are saved at: {filePath}");
        });
        
        return pathCommand;
    }
}