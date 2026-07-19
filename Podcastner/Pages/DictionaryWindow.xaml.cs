using Podcastner.Services;
using System.Windows;

namespace Podcastner { 

    public partial class DictionaryWindow : Window
    {
        public DictionaryWindow()
        {
            InitializeComponent();
        } 
        
        private async void BuscarPalabra_Click(object sender, RoutedEventArgs e)
        {
            DictionaryService service = new();

            string json =
                await service.BuscarPalabra(WordBox.Text);

            DictionaryResult.Text = json;
        }
    }
  

    }
