using System.Text.Json.Serialization;

namespace Podcastner.Models;

public class DictionaryResponse
{
    [JsonPropertyName("word")]
    public string Word { get; set; } = "";

    [JsonPropertyName("phonetic")]
    public string? Phonetic { get; set; }

    [JsonPropertyName("meanings")]
    public List<Meaning> Meanings { get; set; } = [];
}

public class Meaning
{
    [JsonPropertyName("partOfSpeech")]
    public string PartOfSpeech { get; set; } = "";

    [JsonPropertyName("definitions")]
    public List<Definitions> Definitions { get; set; } = [];
}

public class Definitions
{
    [JsonPropertyName("definition")]
    public string Definition { get; set; } = "";

    [JsonPropertyName("example")]
    public string? Example { get; set; }

    [JsonPropertyName("synonyms")]
    public List<string> Synonyms { get; set; } = [];
}