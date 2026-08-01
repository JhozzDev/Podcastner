
using System.Windows;
using System.Windows.Controls;
using Podcastner.Views;
using Podcastner.Services;

namespace Podcastner;

public partial class MainWindow : Window
{
    private readonly WhisperService whisper = new();

     public MainWindow()
    {
        InitializeComponent();

    }

    async private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await whisper.InitializeAsync();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            switch (button.Name)
            {
                case "Podcast":
                    MainContent.Content = new PodcastView();
                    break;
                case "Dictionary": 
                    MainContent.Content = new DictionaryView();
                    break;
                case "Words":
                    MainContent.Content = new WordsView();
                    break;
                default:
                    break;
            }
        }
    }




}