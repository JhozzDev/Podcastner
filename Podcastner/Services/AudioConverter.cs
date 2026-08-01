using Microsoft.VisualBasic;
using NAudio.Wave;
using System.IO;

namespace Podcastner.Services;

public class AudioConverter
{
    public string ConvertMp3ToWav(string mp3Path)
    {
        string wavPath = Path.ChangeExtension(mp3Path, ".wav");

        using var reader = new AudioFileReader(mp3Path);

        WaveFormat outFormat = new WaveFormat(16000, 16, 1);

        using var resampler = new MediaFoundationResampler(reader, outFormat)
        {
            ResamplerQuality = 60
        };

        WaveFileWriter.CreateWaveFile(wavPath, resampler);

        return wavPath;
    }
}