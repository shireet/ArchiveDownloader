using AwesomeFiles.BLL.Services.GetAllFiles;
using AwesomeFiles.BLL.Services.GetArchive;
using AwesomeFiles.BLL.Services.GetArchiveTaskStatus;
using AwesomeFiles.BLL.Services.StartArchive;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeFiles.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBllServices(
        this IServiceCollection services)
    {
        return services;
    }
}