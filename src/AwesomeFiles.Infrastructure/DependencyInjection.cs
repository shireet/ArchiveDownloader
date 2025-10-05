using AwesomeFiles.Infrastructure.Repositories.Implementations;
using AwesomeFiles.Infrastructure.Repositories.Interfaces;
using AwesomeFiles.Infrastructure.Repositories.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AwesomeFiles.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDalServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IArchiveRepository, ArchiveRepository>();
        services.AddSingleton<IArchiveTaskStatusRepository, ArchiveTaskStatusRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        
        services.Configure<DirectoryOptions>(configuration.GetSection("DirectoryOptions"));
        services.AddSingleton(x => x.GetRequiredService<IOptions<DirectoryOptions>>().Value);
        return services;
    }
}