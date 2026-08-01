using Podcastner.Models;
using Podcastner.Services;
using System.Windows;
using System.Windows.Controls;

namespace Podcastner.Views
{
   
    public partial class WordsView : UserControl
    {
        private readonly SavesWord WordService = new();

        public WordsView()
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

