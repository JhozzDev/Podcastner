using Podcastner.Models;
using Podcastner.Services;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Podcastner;

public partial class MainWindow : Window
{
    private readonly MediaPlayer player = new();

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

    private void PodcastList_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (PodcastList.SelectedItem is Podcast podcast)
        {
            PodcastTitle.Text = podcast.Name;
            PodcastDescription.Text = podcast.Description;
        }
    }
}