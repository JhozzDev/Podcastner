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

            PodcastSearchResponse respuesta =
                await service.BuscarPodcasts("english");


            if (respuesta == null)
            {
                MessageBox.Show("Respuesta es null");
                return;
            }


            if (respuesta.Data == null)
            {
                MessageBox.Show("Data es null");
                return;
            }


            if (respuesta.Data.SearchForTerm == null)
            {
                MessageBox.Show("SearchForTerm es null");
                return;
            }


            if (respuesta.Data.SearchForTerm.PodcastSeries == null)
            {
                MessageBox.Show("PodcastSeries es null");
                return;
            }


            PodcastList.ItemsSource =
                respuesta.Data.SearchForTerm.PodcastSeries;

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
            NowPlayingTitle.Text = episode.Name;
        }
    }

    private void Play_Click(object sender, RoutedEventArgs e)
    {
        if (episodioActual == null)
        {
            MessageBox.Show("No hay episodio seleccionado");
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