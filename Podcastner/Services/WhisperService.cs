using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using Whisper.net;
using Whisper.net.Ggml;


namespace Podcastner.Services
{
    public class WhisperService
    {
        private WhisperFactory? _factory;

  
        public async Task<string> DownloadModelAsync()
        {
            string modelPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ggml-base.bin"
            );

            if (!File.Exists(modelPath))
            {
                using var modelStream =
                    await WhisperGgmlDownloader.Default.GetGgmlModelAsync(GgmlType.Base);

                await using var fileWriter = File.Create(modelPath);

                await modelStream.CopyToAsync(fileWriter);
            }

            return modelPath;
        }


        public async Task InitializeAsync()
        {
            if (_factory != null)
                return;

            string modelPath = await DownloadModelAsync();

            _factory = WhisperFactory.FromPath(modelPath);
        }


        public async Task<string> TranscribeAsync(string wavPath)
        {
            try
            {
                MessageBox.Show("1");

                await InitializeAsync();

                MessageBox.Show("2");

                var sb = new StringBuilder();

                using var processor = _factory!
                    .CreateBuilder()
                    .WithLanguage("en")
                    .Build();

                MessageBox.Show("3");

                using var fileStream = File.OpenRead(wavPath);

                MessageBox.Show("4");

                await foreach (var segment in processor.ProcessAsync(fileStream))
                {
                    MessageBox.Show(segment.Text);

                    sb.AppendLine(segment.Text);
                }

                MessageBox.Show("5");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        public async Task<string> DownloadAudioAsync(string audioUrl)
        {
            using HttpClient client = new();

            string tempFolder = Path.Combine(
                Path.GetTempPath(),
                "Podcastner"
            );

            Directory.CreateDirectory(tempFolder);

            string mp3Path = Path.Combine(
                tempFolder,
                $"{Guid.NewGuid()}.mp3"
            );

            byte[] bytes = await client.GetByteArrayAsync(audioUrl);

            await File.WriteAllBytesAsync(mp3Path, bytes);

            return mp3Path;
        }
    }
}