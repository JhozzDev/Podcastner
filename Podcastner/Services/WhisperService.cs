using Whisper.net;
using Whisper.net.Ggml;
using System.IO;

namespace Podcastner.Services;

public class WhisperService
{
    public async Task<string> DownloadModelAsync()
    {
        string modelPath = "ggml-base.bin";

        if (!File.Exists(modelPath))
        {
            using var modelStream =
                await WhisperGgmlDownloader.Default.GetGgmlModelAsync(GgmlType.Base);

            using var fileWriter = File.OpenWrite(modelPath);

            await modelStream.CopyToAsync(fileWriter);
        }

        return modelPath;
    }
}