using Podcastner.Models;
using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace Podcastner.Services;

public class DictionaryService
{
    private readonly HttpClient client = new();

    public async Task<DictionaryResponse?> BuscarPalabra(string palabra)
    {
        string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{palabra}";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        string json = await response.Content.ReadAsStringAsync();

        var resultado = JsonSerializer.Deserialize<List<DictionaryResponse>>(json);

        return resultado?.FirstOrDefault();
    }
}