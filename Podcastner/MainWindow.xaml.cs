using Podcastner.Models;
using Podcastner.Services;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Podcastner;

public partial class MainWindow : Window
{
    private readonly MediaPlayer player = new();
    private readonly DispatcherTimer timer = new();

    private Episode episodioActual = new();
    private bool usuarioMoviendoBarra = false;
    
    
    
    public MainWindow()
    {
        InitializeComponent();

        timer.Interval = TimeSpan.FromMilliseconds(300);
        timer.Tick += Timer_Tick;

    }


    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (!player.NaturalDuration.HasTimeSpan)
            return;

        if (!usuarioMoviendoBarra)
        {
            AudioSlider.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
            AudioSlider.Value = player.Position.TotalSeconds;

            TiempoActual.Text = player.Position.ToString(@"mm\:ss");
            TiempoTotal.Text = player.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        }
    }


    private async void CargarPodcasts(object sender, RoutedEventArgs e)
    {
        try
        {
            PodcastService service = new();

            PodcastSearchResponse respuesta =
                await service.BuscarPodcasts(SearchBox.Text);


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

        player.Open(new Uri(episodioActual.AudioUrl));

        player.MediaOpened += Player_MediaOpened;

        player.Play();
    }

    private void AudioSlider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        usuarioMoviendoBarra = true;
    }

    private void AudioSlider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        usuarioMoviendoBarra = false;
        player.Position = TimeSpan.FromSeconds(AudioSlider.Value);
    }

    private void AudioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (usuarioMoviendoBarra)
        {
           
            player.Position = TimeSpan.FromSeconds(AudioSlider.Value);
        }
    }
    private void Player_MediaOpened(object? sender, EventArgs e)
    {
        timer.Start();
    }

    private void Player_MediaEnded(object? sender, EventArgs e)
    {
        timer.Stop();
        AudioSlider.Value = 0;
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