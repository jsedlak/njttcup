using System.Net.Http.Json;
using CupKeeper.Cqrs;

namespace CupKeeper.AdminApp.Services;

public abstract class ApiServiceBase
{
    private readonly HttpClient _apiClient;
    
    protected ApiServiceBase(IHttpClientFactory httpClientFactory)
    {
        _apiClient = httpClientFactory.CreateClient(ServiceConstants.ApiHttpClientName);
    }

    protected async Task<TResponse> GetAsync<TResponse>(string path)
    {
        var response = await _apiClient.GetFromJsonAsync<TResponse>(path);
        return response ?? throw new InvalidOperationException();
    }
    
    protected async Task<TResult?> PostAsJsonAsync<TResult>(string path, object input)
    {
        var response = await _apiClient.PostAsJsonAsync(path, input);
        return await response.Content.ReadFromJsonAsync<TResult>();
    }
    
    protected async Task<HttpResponseMessage> PostAsync(string path, object input)
    {
        var response = await _apiClient.PostAsJsonAsync(path, input);
        return response;
    }

    protected async Task<CommandResult> ExecuteAsync<TCommand>(string path, TCommand command)
    {
        var response = await _apiClient.PostAsJsonAsync(path, command);
        return (await response.Content.ReadFromJsonAsync<CommandResult>()) ?? CommandResult.Failure("Server error");
    }
    
    protected async Task<CommandResult<TResult>> ExecuteAsync<TCommand, TResult>(string path, TCommand command)
    {
        var response = await _apiClient.PostAsJsonAsync(path, command);
        return (await response.Content.ReadFromJsonAsync<CommandResult<TResult>>()) ?? 
               CommandResult<TResult>.Failure("Server error");
    }
    
    protected async Task<HttpResponseMessage> DeleteAsync(string path)
    {
        return await _apiClient.DeleteAsync(path);
    }
    
    protected async Task<CommandResult> DeleteWithResultAsync(string path)
    {
        var response = await _apiClient.DeleteAsync(path);
        return (await response.Content.ReadFromJsonAsync<CommandResult>()) ?? CommandResult.Failure("Server error");
    }
}