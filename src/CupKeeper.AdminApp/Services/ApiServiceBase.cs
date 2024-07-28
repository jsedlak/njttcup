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
}