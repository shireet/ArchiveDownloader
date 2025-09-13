namespace AwesomeFiles.DAL.Settings;

public record DalOptions
{
    public required string RedisConnectionString { get; init; } = string.Empty;
}