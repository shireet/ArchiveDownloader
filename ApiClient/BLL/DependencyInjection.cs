using ApiClient.BLL.Implementations;
using ApiClient.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApiClient.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddScoped<IArchiveService, ArchiveService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IStatusService, StatusService>();
        return services;
    }
}