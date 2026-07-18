using Podcastner.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Podcastner.Services;

public class PodcastService
{
    private readonly HttpClient client = new();


    public PodcastService()
    {
        client.DefaultRequestHeaders.Add(
            "X-USER-ID",
            "5164"
        );

        client.DefaultRequestHeaders.Add(
            "X-API-KEY",
            "2073c4457672fdb38566153da015423cd7d26b8c609e97ebc2be91536aa86a2f6ad527f98ccc94c88ecb8c0864820d4dd2"
        );
    }


    public async Task<PodcastSearchResponse> BuscarPodcasts(string termino)
    {
        string query = $@"
{{
  searchForTerm(term:""{termino}""){{
    searchId

    podcastSeries{{
      uuid
      name
      description
      imageUrl
      totalEpisodesCount

      episodes{{
        uuid
        name
        description
        audioUrl
        subtitle
   
      }}
    }}
  }}
}}";

        string body = $$"""
{
    "query": {{JsonSerializer.Serialize(query)}}
}
""";


        var content = new StringContent(
            body,
            Encoding.UTF8,
            "application/json"
        );


        var response = await client.PostAsync(
            "https://api.taddy.org",
            content
        );


        var json = await response.Content.ReadAsStringAsync();
        MessageBox.Show(json);

        PodcastSearchResponse resultado =
            JsonSerializer.Deserialize<PodcastSearchResponse>(json)!;


        return resultado;
    }
}