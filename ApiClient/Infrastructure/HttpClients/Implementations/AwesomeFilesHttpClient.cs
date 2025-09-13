using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ApiClient.Infrastructure.HttpClients.Interfaces;

namespace ApiClient.Infrastructure.HttpClients.Implementations;

public class AwesomeFilesHttpClient : IAwesomeFilesHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public AwesomeFilesHttpClient(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(endpoint, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<T>(content, _jsonOptions)!;
        }

        public async Task<T> PostAsync<T>(string endpoint, object data, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(endpoint, content, cancellationToken);
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<T>(responseContent, _jsonOptions)!;
        }

        public async Task<Stream?> GetStreamAsync(string endpoint, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(endpoint, cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            
            return await response.Content.ReadAsStreamAsync(cancellationToken);
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }