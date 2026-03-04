namespace Sitecore.AspNetCore.Starter.Services;

/// <summary>
/// Service for retrieving Sitecore Dictionary entries.
/// Dictionary items are managed in the CMS by content authors.
/// </summary>
public interface IDictionaryService
{
    /// <summary>
    /// Get a single dictionary phrase by key.
    /// </summary>
    /// <param name="key">Dictionary entry key (e.g. "HEADER_SEARCH")</param>
    /// <param name="language">Language code (e.g. "en")</param>
    /// <returns>The translated phrase, or the key itself if not found.</returns>
    Task<string> GetAsync(string key, string language = "en");

    /// <summary>
    /// Get all dictionary entries for a language.
    /// </summary>
    Task<IDictionary<string, string>> GetAllAsync(string language = "en");
}
