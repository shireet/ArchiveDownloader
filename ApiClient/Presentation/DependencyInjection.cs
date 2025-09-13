using Microsoft.Extensions.DependencyInjection;

namespace ApiClient.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddSingleton<CommandHandler>();
        return services;
    }
}