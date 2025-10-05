namespace AwesomeFiles.Infrastructure.AwesomeFiles.Infrastructure.Repositories.Settings;

public record DalOptions
{
    public required string RedisConnectionString { get; init; } = string.Empty;
}