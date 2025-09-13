using ApiClient.Infrastructure.HttpClients.Implementations;
using ApiClient.Infrastructure.HttpClients.Interfaces;
using ApiClient.Infrastructure.Providers.Implementations;
using ApiClient.Infrastructure.Providers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApiClient.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string s)
    {
        services.AddSingleton<IAwesomeFilesHttpClient, AwesomeFilesHttpClient>();
        services.AddSingleton<IAwesomeFilesHttpClient>(x => new AwesomeFilesHttpClient(s));
        
        services.AddScoped<IArchiveInitializer, ArchiveInitializer>();
        services.AddScoped<IArchiveStatusProvider, ArchiveStatusProvider>();
        services.AddScoped<IFileProvider, FileProvider>();
        return services;
    }
}