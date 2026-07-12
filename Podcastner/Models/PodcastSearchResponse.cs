using System.Text.Json.Serialization;

namespace Podcastner.Models;

public class PodcastSearchResponse
{
    [JsonPropertyName("data")]
    public SearchData Data { get; set; }
}


public class SearchData
{
    [JsonPropertyName("searchForTerm")]
    public SearchResult SearchForTerm { get; set; }
}

public class SearchResult
{
    [JsonPropertyName("searchId")]
    public string SearchId { get; set; }

    [JsonPropertyName("podcastSeries")]
    public List<Podcast> PodcastSeries { get; set; } = [];
}