using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatFact.Configuration;

public static class ConfigurationInstaller
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        services.Configure<CatFactApiConfiguration>(configuration.GetSection(CatFactApiConfiguration.SectionName));
        services.Configure<StorageConfiguration>(configuration.GetSection(StorageConfiguration.SectionName));
        return services;
    }
}