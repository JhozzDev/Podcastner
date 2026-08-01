using Podcastner.Models;
using Podcastner.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Podcastner.Views
{

    public partial class DictionaryView : UserControl
    {
        public DictionaryView()
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


            SavesWord serviceWord = new();
            SavedWord insert = new()
            {
                Word = palabra.Word,
                Phonetic = palabra.Phonetic,
                PartOfSpeech = palabra.Meanings[0].PartOfSpeech,
                Definition = palabra.Meanings[0].Definitions[0].Definition,
                Example = palabra.Meanings[0].Definitions[0].Example
            };

            serviceWord.AddWord(insert);
            DictionaryResult.Text = sb.ToString();
        }
    }
}