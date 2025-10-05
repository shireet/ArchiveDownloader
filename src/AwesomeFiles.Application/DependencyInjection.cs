using AwesomeFiles.Application.Services.GetAllFiles;
using AwesomeFiles.Application.Services.GetArchive;
using AwesomeFiles.Application.Services.GetArchiveTaskStatus;
using AwesomeFiles.Application.Services.StartArchive;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeFiles.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetAllFilesHandler).Assembly));
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetArchiveHandler).Assembly));
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(GetArchiveTaskStatusHandler).Assembly));
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(StartArchiveHandler).Assembly));
        return services;
    }
}