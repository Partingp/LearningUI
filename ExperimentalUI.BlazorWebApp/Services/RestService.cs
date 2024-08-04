namespace ExperimentalUI.BlazorWebApp.Services;

using ExperimentalUI.BlazorWebApp.Interfaces;
using ExperimentalUI.BlazorWebApp.Models.Options;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RestService<T, TOptions> : IRestService<T, TOptions>
    where T : class
    where TOptions : RestOptions
{
    private readonly ILogger _logger;
    private readonly RestClient _client;
    private readonly RestOptions _options;

    public RestService(ILogger<RestService<T, TOptions>> logger, IOptions<TOptions> options)
    {
        _logger = logger;
        _client = new RestClient(options.Value.EndpointUrl);
        _options = options.Value;
    }

    public async Task<T> CreateAsync(T entity)
    {
        var request = new RestRequest(_options.CreateResource, Method.Post);
        request.AddJsonBody(entity);

        var response = await _client.ExecuteAsync<T>(request);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Unable to create entity {Entity}", entity);
        }

        return response.Data;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var request = new RestRequest(_options.GetByIdResource, Method.Get);
        request.AddUrlSegment("id", id);
        var response = await _client.ExecuteAsync<T>(request);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Unable to get entity {Id}", id);
        }

        return response.Data;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var request = new RestRequest(_options.GetResource, Method.Get);
        var response = await _client.ExecuteAsync<List<T>>(request);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Unable to get entities");
        }

        return response.Data;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        var request = new RestRequest(_options.UpdateResource, Method.Put);
        request.AddUrlSegment("id", id);
        request.AddJsonBody(entity);

        var response = await _client.ExecuteAsync<T>(request);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Unable to update entity {Id}", id);
        }

        return response.Data;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var request = new RestRequest(_options.DeleteResource, Method.Delete);
        request.AddUrlSegment("id", id);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            _logger.LogError("Unable to delete entity {Id}", id);
        }

        return response.IsSuccessful;
    }
}