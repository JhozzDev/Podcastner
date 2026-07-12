using System.Text.Json.Serialization;

public class EpisodesResponse
{
    [JsonPropertyName("items")]
    public List<Episode> Items { get; set; } = [];
}