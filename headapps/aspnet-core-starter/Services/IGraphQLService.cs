namespace Sitecore.AspNetCore.Starter.Services;

/// <summary>
/// Generic service to execute GraphQL queries against Sitecore Experience Edge.
/// </summary>
public interface IGraphQLService
{
    /// <summary>
    /// Executes a GraphQL query and returns the typed data.
    /// </summary>
    /// <typeparam name="T">The type of the data object in the response.</typeparam>
    /// <param name="query">The GraphQL query string.</param>
    /// <param name="variables">Optional variables for the query.</param>
    Task<T> ExecuteAsync<T>(string query, object? variables = null);

    /// <summary>
    /// Executes a GraphQL query from a specified file (relative to GraphQL/Queries/) and returns the typed data.
    /// </summary>
    /// <typeparam name="T">The type of the data object in the response.</typeparam>
    /// <param name="queryFileName">The name of the .graphql file (with or without extension).</param>
    /// <param name="variables">Optional variables for the query.</param>
    Task<T> ExecuteFromFileAsync<T>(string queryFileName, object? variables = null);
}
