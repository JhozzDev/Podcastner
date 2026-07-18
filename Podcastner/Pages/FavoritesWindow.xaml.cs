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
}