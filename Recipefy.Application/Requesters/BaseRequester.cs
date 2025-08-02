using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Recipefy.Application.Contracts.Common;
using Recipefy.Application.Requesters.Common;

namespace Recipefy.Application.Requesters;

public class BaseRequester : IBaseRequester
{
    private readonly HttpClient _httpClient;
    
    public BaseRequester()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(this.BaseUrl)
        };
    }
    public string BaseUrl { get; protected set; }

    public async Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default) =>
        await SendAsync<T>(url, null, HttpRequestType.Get, cancellationToken).ConfigureAwait(false);
    
    public async Task<T?> DeleteAsync<T>(string url, CancellationToken cancellationToken = default) =>
        await SendAsync<T>(url, null, HttpRequestType.Delete, cancellationToken).ConfigureAwait(false);
    
    public async Task PostAsync<T>(string url, T model,CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(model);
        
        await SendAsync<T>(url, json, HttpRequestType.Post, cancellationToken).ConfigureAwait(false);
    }
    
    public async Task PutAsync<T>(string url, T model,CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(model);
        
        await SendAsync<T>(url, json, HttpRequestType.Put, cancellationToken).ConfigureAwait(false);
    }
    
    private async Task<T?> SendAsync<T>(string query, string? json, HttpRequestType type, CancellationToken token)
    {
        HttpContent? content = null;

        if (!string.IsNullOrEmpty(json))
        {
            content = new StringContent(json, Encoding.UTF8, "application/json");
        }
        
        var response = type switch
        {
            HttpRequestType.Get => await _httpClient.GetAsync(query, token),
            HttpRequestType.Put => await _httpClient.PutAsync(query, content!, token),
            HttpRequestType.Post => await _httpClient.PostAsync(query, content!, token),
            HttpRequestType.Delete => await _httpClient.DeleteAsync(query, token),
            _ => await _httpClient.GetAsync(query, token)
        };
        
        return await response.Content.ReadFromJsonAsync<T>(token);
    }
}