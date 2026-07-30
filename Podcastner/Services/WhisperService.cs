using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using Whisper.net;
using Whisper.net.Ggml;

namespace Podcastner.Services;

public class WhisperService
{
    public async Task<string> DownloadModelAsync()
    {
        string modelPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "ggml-base.bin"
        );

        MessageBox.Show($"Ruta del modelo:\n{modelPath}");

        if (!File.Exists(modelPath))
        {
            using var modelStream =
                await WhisperGgmlDownloader.Default.GetGgmlModelAsync(GgmlType.Base);
            await using var fileWriter = File.Create(modelPath);

            await modelStream.CopyToAsync(fileWriter);
        }

        return modelPath;
    }


    public async Task<string> TranscribeAsync(string wavPath)
{
     string modelPath = await DownloadModelAsync();

        var sb = new StringBuilder();

    using var factory = WhisperFactory.FromPath(modelPath);

    using var processor = factory
        .CreateBuilder()
        .WithLanguage("en")
        .Build();

    using var fileStream = File.OpenRead(wavPath);

    await foreach (var segment in processor.ProcessAsync(fileStream))
    {
        sb.AppendLine(segment.Text);
    }

    return sb.ToString();
}


    public async Task<string> DownloadAudioAsync(string audioUrl)
    {
        using HttpClient client = new();

        string tempFolder = Path.Combine(Path.GetTempPath(), "Podcastner");

        Directory.CreateDirectory(tempFolder);

        string mp3Path = Path.Combine(tempFolder, Guid.NewGuid() + ".mp3");

        byte[] bytes = await client.GetByteArrayAsync(audioUrl);

        await File.WriteAllBytesAsync(mp3Path, bytes);

        return mp3Path;
    }
}

