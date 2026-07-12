using System.Text.Json.Serialization;

public class Episode
{
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("audioUrl")]
    public string AudioUrl { get; set; }
}