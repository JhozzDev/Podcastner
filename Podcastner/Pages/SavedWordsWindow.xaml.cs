using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Podcastner
{
    /// <summary>
    /// Lógica de interacción para SavedWordsWindow.xaml
    /// </summary>
    public partial class SavedWordsWindow : Window
    {
        private readonly string connectionString =
           "Data Source=podcastner.db";

        public SavedWordsWindow()
        {
            InitializeComponent();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
        CREATE TABLE IF NOT EXISTS SavedWords
        (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Word TEXT NOT NULL,
            Phonetic TEXT,
            PartOfSpeech TEXT,
            Definition TEXT,
            Example TEXT
        );
        """;

            command.ExecuteNonQuery();
        }
    }
}

    
