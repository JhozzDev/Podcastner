using System.Text.Json.Serialization;

namespace Podcastner.Models;

public class PodcastResponse
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class Data
{
    [JsonPropertyName("getPodcastSeries")]
    public Podcast Podcast { get; set; }
}

public class Podcast
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("itunesId")]
    public long ItunesId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("totalEpisodesCount")]
    public int TotalEpisodesCount { get; set; }

    [JsonPropertyName("itunesInfo")]
    public ItunesInfo ItunesInfo { get; set; }
}

public class ItunesInfo
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("baseArtworkUrlOf")]
    public string BaseArtworkUrlOf { get; set; }
}