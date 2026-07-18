using Podcastner.Models;
using Podcastner.Services;
using System.Windows;
using System.Windows.Media;

namespace Podcastner;

public partial class FavoritesWindow : Window
{
    private readonly FavoriteService favoriteService = new();

    public FavoritesWindow()
    {
        InitializeComponent();

        FavoritesList.ItemsSource = favoriteService.GetFavorites();
    }

    private void Remove_list(object sender, RoutedEventArgs e)
    {
        if (FavoritesList.SelectedItem is not FavoritePodcast Fvp)
            return;
         
        favoriteService.Remove(Fvp.Uuid);


    }
}