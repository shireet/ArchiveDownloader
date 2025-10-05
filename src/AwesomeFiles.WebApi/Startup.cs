using AwesomeFiles.Application;
using AwesomeFiles.Infrastructure;
using AwesomeFiles.WebApi.Middleware;
using AwesomeFiles.WebApi.Validators;
using FluentValidation.AspNetCore;

namespace AwesomeFiles.WebApi;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    [Obsolete("Obsolete")]
    public void ConfigureServices(IServiceCollection services)
    {
        var currentAssembly = typeof(Startup).Assembly;
        services
            .AddMediatR(c => c.RegisterServicesFromAssembly(currentAssembly));
        services.AddControllers()
            .AddFluentValidation(fv => 
            {
                fv.RegisterValidatorsFromAssemblyContaining<StartArchiveRequestValidator>();
                fv.AutomaticValidationEnabled = true;
            });
        services.AddSwaggerGen();
        

        services.AddMvc(
            x =>
            {
                x.Filters.Add(typeof(BusinessExceptionFilter));
            });
        
        services.AddSwaggerGen()
                .AddDalServices(_configuration)
                .AddApplication();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseMiddleware<LoggingMiddleware>();
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}