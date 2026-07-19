using System.Net.Http;
using System.Text.Json;

namespace Podcastner.Services;

public class DictionaryService
{
    private readonly HttpClient client = new();

    public async Task<string> BuscarPalabra(string palabra)
    {
        string url =
            $"https://api.dictionaryapi.dev/api/v2/entries/en/{palabra}";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return "Palabra no encontrada.";

        return await response.Content.ReadAsStringAsync();
    }
}