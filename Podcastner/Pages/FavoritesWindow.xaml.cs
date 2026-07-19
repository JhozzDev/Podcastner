using Podcastner.Models;
using Podcastner.Services;
using System.Windows;


namespace Podcastner;

public partial class FavoritesWindow : Window
{
    private readonly FavoriteService favoriteService = new();

    public FavoritesWindow()
    {
        InitializeComponent();

        FavoritesList.ItemsSource = favoriteService.GetFavorites();
    }
    private void Remove(object sender, RoutedEventArgs e)
    {
        if (FavoritesList.SelectedItem is not FavoritePodcast fvp)
            return;

        MessageBox.Show(fvp.Uuid);

        favoriteService.Remove(fvp.Uuid);

        FavoritesList.ItemsSource = null;
        FavoritesList.ItemsSource = favoriteService.GetFavorites();
    }
}