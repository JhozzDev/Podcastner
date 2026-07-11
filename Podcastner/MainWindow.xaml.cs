using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Podcastner.Models;

namespace Podcastner;

public partial class MainWindow : Window
{
    private readonly MediaPlayer player = new();

    public MainWindow()
    {
        InitializeComponent();

        List<Podcast> podcasts =
        [
            new Podcast
            {
                Title = "6 Minute English",
                Author = "BBC Learning English",
                Description = "Improve your vocabulary with short lessons.",
                AudioPath = "Resources/Audio/Yo.mp3"
            },

            new Podcast
            {
                Title = "The English We Speak",
                Author = "BBC Learning English",
                Description = "Learn everyday English expressions.",
                AudioPath = "Resources/Audio/english2.mp3"
            },

            new Podcast
            {
                Title = "All Ears English",
                Author = "AEE",
                Description = "English conversation practice.",
                AudioPath = "Resources/Audio/english3.mp3"
            }
        ];

        PodcastList.ItemsSource = podcasts;

        PodcastList.SelectionChanged += PodcastList_SelectionChanged;
    }

    private void PodcastList_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (PodcastList.SelectedItem is Podcast podcast)
        {
            PodcastTitle.Text = podcast.Title;
            PodcastAuthor.Text = podcast.Author;
            PodcastDescription.Text = podcast.Description;
        }
    }

    private void Play_Click(object sender, RoutedEventArgs e)
    {
        if (PodcastList.SelectedItem is not Podcast podcast)
        {
            MessageBox.Show("Selecciona un podcast.");
            return;
        }

        player.Open(new Uri(podcast.AudioPath, UriKind.Relative));
        player.Play();
    }

    private void Pause_Click(object sender, RoutedEventArgs e)
    {
        player.Pause();
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        player.Stop();
    }

    private void Back10_Click(object sender, RoutedEventArgs e)
    {
        var nuevaPosicion = player.Position - TimeSpan.FromSeconds(10);

        player.Position = nuevaPosicion < TimeSpan.Zero
            ? TimeSpan.Zero
            : nuevaPosicion;
    }

    private void Forward10_Click(object sender, RoutedEventArgs e)
    {
        if (!player.NaturalDuration.HasTimeSpan)
            return;

        var nuevaPosicion = player.Position + TimeSpan.FromSeconds(10);

        player.Position = nuevaPosicion > player.NaturalDuration.TimeSpan
            ? player.NaturalDuration.TimeSpan
            : nuevaPosicion;
    }

    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.A)
        {
            Back10_Click(sender, e);
        }

        if (e.Key == Key.D)
        {
            Forward10_Click(sender, e);
        }
    }
}