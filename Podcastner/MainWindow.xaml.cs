using Podcastner.Models;
using Podcastner.Services;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Podcastner;

public partial class MainWindow : Window
{

    private readonly MediaPlayer player = new();
    private Episode episodioActual;
    public MainWindow()
    {
        InitializeComponent();

        CargarPodcasts();
    }

    private async void CargarPodcasts()
    {
        try
        {
            PodcastService service = new();

            PodcastResponse respuesta =
                await service.ObtenerPodcast();

            PodcastList.ItemsSource = new List<Podcast>
        {
            respuesta.Data.Podcast
        };

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    private void EpisodeList_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (EpisodeList.SelectedItem is Episode episode)
        {
            episodioActual = episode;

    
        }
    }

    private void Play_Click(object sender, RoutedEventArgs e)
    {
        if (episodioActual == null)
        {
            MessageBox.Show("Selecciona un episodio.");
            return;
        }


        player.Open(
            new Uri(episodioActual.AudioUrl)
        );

        player.Play();
    }

    private void PodcastList_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (PodcastList.SelectedItem is Podcast podcast)
        {
            PodcastTitle.Text = podcast.Name;
            PodcastDescription.Text = podcast.Description;

            PodcastImage.Source = new BitmapImage(
                new Uri(podcast.ImageUrl)
            );

            EpisodeList.ItemsSource = podcast.Episodes;
        }
    }
}