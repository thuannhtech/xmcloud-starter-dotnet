using Microsoft.Extensions.Caching.Memory;
using Sitecore.AspNetCore.Starter.Models;

namespace Sitecore.AspNetCore.Starter.Services;

/// <summary>
/// Optimized Dictionary Service using the Core GraphQL Service.
/// </summary>
public class SitecoreDictionaryService : IDictionaryService
{
    private readonly IGraphQLService _graphQLService;
    private readonly IMemoryCache _cache;
    private readonly SitecoreSettings _settings;
    private readonly ILogger<SitecoreDictionaryService> _logger;

    private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(10);
    public SitecoreDictionaryService(
        IGraphQLService graphQLService,
        IMemoryCache cache,
        SitecoreSettings settings,
        ILogger<SitecoreDictionaryService> logger)
    {
        _graphQLService = graphQLService;
        _cache = cache;
        _settings = settings;
        _logger = logger;
    }

    public async Task<string> GetAsync(string key, string language = "en")
    {
        var dictionary = await GetAllAsync(language);
        return dictionary.TryGetValue(key, out var value) ? value : key;
    }

    public async Task<IDictionary<string, string>> GetAllAsync(string language = "en")
    {
        var cacheKey = $"sitecore_dictionary_{_settings.DefaultSiteName}_{language}";

        if (_cache.TryGetValue(cacheKey, out IDictionary<string, string>? cached))
        {
            return cached!;
        }

        try
        {
            var data = await _graphQLService.ExecuteFromFileAsync<DictionaryResponse>("DictionarySearch", new
            {
                siteName = _settings.DefaultSiteName,
                language
            });

            var dictionary = data.Site?.SiteInfo?.Dictionary?.Results?
                .Where(r => !string.IsNullOrEmpty(r.Key))
                .ToDictionary(r => r.Key!, r => r.Value ?? string.Empty, StringComparer.OrdinalIgnoreCase) 
                ?? new Dictionary<string, string>();

            _cache.Set(cacheKey, dictionary, CacheDuration);
            return dictionary;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Fallback: Could not load dictionary for {Lang}. Returning empty.", language);
            return new Dictionary<string, string>();
        }
    }

    #region Local Data Models

    private class DictionaryResponse
    {
        public SiteData? Site { get; set; }
    }

    private class SiteData
    {
        public SiteInfoData? SiteInfo { get; set; }
    }

    private class SiteInfoData
    {
        public DictionaryData? Dictionary { get; set; }
    }

    private class DictionaryData
    {
        public List<DictionaryEntry>? Results { get; set; }
    }

    private class DictionaryEntry
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }

    #endregion
}
