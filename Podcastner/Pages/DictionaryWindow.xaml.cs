using Podcastner.Services;
using System.Text;
using System.Windows;

namespace Podcastner
{

    public partial class DictionaryWindow : Window
    {
        public DictionaryWindow()
        {
            InitializeComponent();
        }

        private async void BuscarPalabra_Click(object sender, RoutedEventArgs e)
        {
            DictionaryService service = new();

            var palabra = await service.BuscarPalabra(WordBox.Text);

            if (palabra == null)
            {
                DictionaryResult.Text = "Palabra no encontrada.";
                return;
            }

            StringBuilder sb = new();

            sb.AppendLine($"Word: {palabra.Word}");
            sb.AppendLine($"Phonetic: {palabra.Phonetic}");
            sb.AppendLine();

            foreach (var meaning in palabra.Meanings)
            {
                sb.AppendLine($"Part of speech: {meaning.PartOfSpeech}");

                foreach (var definition in meaning.Definitions)
                {
                    sb.AppendLine($"- {definition.Definition}");

                    if (!string.IsNullOrWhiteSpace(definition.Example))
                        sb.AppendLine($"  Example: {definition.Example}");
                }

                sb.AppendLine();
            }

            DictionaryResult.Text = sb.ToString();
        }
    }
}