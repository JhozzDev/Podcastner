using Podcastner.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Podcastner.Services;

public class PodcastService
{
    private readonly HttpClient client = new();

    public async Task<PodcastResponse> ObtenerPodcast()
    {
        client.DefaultRequestHeaders.Clear();

        client.DefaultRequestHeaders.Add("X-USER-ID", "5164");
        client.DefaultRequestHeaders.Add("X-API-KEY", "2073c4457672fdb38566153da015423cd7d26b8c609e97ebc2be91536aa86a2f6ad527f98ccc94c88ecb8c0864820d4dd2");

        string query = @"
{
  getPodcastSeries(name:""The Daily""){
    uuid
    name
    description
    imageUrl

    episodes{
      uuid
      name
      description
      audioUrl
    }
  }
}";

        string body = $$"""
{
    "query": {{JsonSerializer.Serialize(query)}}
}
""";

        var content = new StringContent(
            body,
            Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync(
            "https://api.taddy.org",
            content);

        string json = await response.Content.ReadAsStringAsync();

        PodcastResponse? resultado =
            JsonSerializer.Deserialize<PodcastResponse>(json);

        if (resultado == null)
        {
            throw new Exception("No se pudo deserializar la respuesta.");
        }

        return resultado;
    }
}