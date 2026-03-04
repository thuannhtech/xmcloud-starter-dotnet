using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Hosting;
using Sitecore.AspNetCore.Starter.Models;

namespace Sitecore.AspNetCore.Starter.Services;

/// <summary>
/// Core implementation for calling Sitecore Content Hub / Experience Edge GraphQL API using GraphQL.Client.
/// </summary>
public class GraphQLService : IGraphQLService
{
    private readonly GraphQLHttpClient _graphQLClient;
    private readonly SitecoreSettings _settings;
    private readonly ILogger<GraphQLService> _logger;
    private readonly IWebHostEnvironment _env;

    public GraphQLService(
        SitecoreSettings settings,
        ILogger<GraphQLService> logger,
        IWebHostEnvironment env)
    {
        var options = new GraphQLHttpClientOptions
        {
            EndPoint = new Uri($"{settings.EdgeEndpoint}?sc_apikey={settings.EdgeDeliveryAPIToken}")
        };

        _graphQLClient = new GraphQLHttpClient(options, new SystemTextJsonSerializer());
        
        _settings = settings;
        _logger = logger;
        _env = env;
    }

    public async Task<T> ExecuteAsync<T>(string query, object? variables = null)
    {
        var request = new GraphQLRequest
        {
            Query = query,
            Variables = variables
        };

        try
        {
            var response = await _graphQLClient.SendQueryAsync<T>(request);

            if (response.Errors != null && response.Errors.Any())
            {
                var errorMessages = string.Join(" | ", response.Errors.Select(e => e.Message));
                _logger.LogError("GraphQL Query returned errors: {Errors}", errorMessages);
                throw new Exception($"GraphQL Execution Error: {errorMessages}");
            }

            if (response.Data == null)
            {
                throw new Exception("GraphQL response contained no data.");
            }

            return response.Data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Critical failure during GraphQL execution.");
            throw;
        }
    }

    public async Task<T> ExecuteFromFileAsync<T>(string queryFileName, object? variables = null)
    {
        if (!queryFileName.EndsWith(".graphql"))
        {
            queryFileName += ".graphql";
        }

        var filePath = Path.Combine(_env.ContentRootPath, "GraphQL", "Queries", queryFileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"GraphQL query file not found at: {filePath}");
        }

        var query = await File.ReadAllTextAsync(filePath);
        return await ExecuteAsync<T>(query, variables);
    }
}
