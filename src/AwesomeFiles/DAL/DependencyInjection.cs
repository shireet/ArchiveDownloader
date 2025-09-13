using AwesomeFiles.DAL.Implementations;
using AwesomeFiles.DAL.Interfaces;
using AwesomeFiles.DAL.Settings;
using Microsoft.Extensions.Options;

namespace AwesomeFiles.DAL;

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