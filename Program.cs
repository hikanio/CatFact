using CatFact.Repositories;
using CatFact.Services;
using Microsoft.Extensions.DependencyInjection;
using CatFact.CLI;
using CatFact.Configuration;

// DI
var services = new ServiceCollection();
services
    .AddConfiguration()
    .AddSingleton<ICatFactRepository, CatFactRepository>();
services.AddHttpClient<ICatFactService, CatFactService>();

// Get services for CLI
var serviceProvider = services.BuildServiceProvider();
var catFactService = serviceProvider.GetRequiredService<ICatFactService>();
var catFactRepository = serviceProvider.GetRequiredService<ICatFactRepository>();

// CLI
var rootCommand = CatFactsCliCommands.CreateRootCommand(catFactService, catFactRepository);
return rootCommand.Parse(args).Invoke();