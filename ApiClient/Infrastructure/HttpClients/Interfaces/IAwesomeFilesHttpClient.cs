namespace ApiClient.Infrastructure.HttpClients.Interfaces;

public interface IAwesomeFilesHttpClient
{
    Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken);
    Task<T> PostAsync<T>(string endpoint, object data, CancellationToken cancellationToken);
    Task<Stream?> GetStreamAsync(string endpoint, CancellationToken cancellationToken);
}