using System.Text.Json.Serialization;

public class Dictionary
{
    [JsonPropertyName("word")]
    public string Word { get; set; }

}
