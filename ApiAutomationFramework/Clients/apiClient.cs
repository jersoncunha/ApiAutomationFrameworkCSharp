
using RestSharp;
using ApiAutomationFramework.Config;

namespace ApiAutomationFramework.Clients;

public class ApiClient
{
    private readonly RestClient _client;

    public ApiClient()
    {
        var options = new RestClientOptions(ApiSettings.BaseUrl)
        {
            MaxTimeout = 30000
        };

        _client = new RestClient(options);
    }

    public async Task<RestResponse<TResponse>> GetAsync<TResponse>(
        string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);

        return await _client.ExecuteAsync<TResponse>(request);
    }

    public async Task<RestResponse<TResponse>> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(body);

        return await _client.ExecuteAsync<TResponse>(request);
    }

    public async Task<RestResponse<TResponse>> PutAsync<TRequest, TResponse>(
        string endpoint,
        TRequest body)
    {
        var request = new RestRequest(endpoint, Method.Put);
        request.AddJsonBody(body);

        return await _client.ExecuteAsync<TResponse>(request);
    }

    public async Task<RestResponse> DeleteAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Delete);

        return await _client.ExecuteAsync(request);
    }
}
