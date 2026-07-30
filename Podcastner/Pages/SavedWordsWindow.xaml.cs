using Podcastner.Models;
using Podcastner.Services;
using System.Windows;

namespace Podcastner
{
    /// <summary>
    /// Lógica de interacción para SavedWordsWindow.xaml
    /// </summary>
    public partial class SavedWordsWindow : Window
    {
        private readonly SavesWord WordService = new();

        public SavedWordsWindow()
        {
            InitializeComponent();
            WordsList.ItemsSource = WordService.GetWords();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (WordsList.SelectedItem is not SavedWord fvp)
                return;

            WordService.Remove(fvp.Word);

            WordsList.ItemsSource = null;
            WordsList.ItemsSource = WordService.GetWords();
        }


    }
}
    
