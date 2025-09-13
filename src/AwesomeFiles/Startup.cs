using AwesomeFiles.BLL;
using AwesomeFiles.DAL;
using AwesomeFiles.Presentation.Middleware;
using AwesomeFiles.Validators;
using FluentValidation.AspNetCore;

namespace AwesomeFiles;

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
        
        services.AddSwaggerGen();
        services.AddBllServices()
                .AddDalServices(_configuration);
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