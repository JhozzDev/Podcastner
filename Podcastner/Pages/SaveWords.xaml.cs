
using Microsoft.Data.Sqlite;
using Podcastner.Services;
using System.Windows;


namespace Podcastner.Pages
{

    public class SavesWord
    {
        private readonly string connectionString =
            "Data Source=podcastner.db";


        public SavesWord()
        {
            InitializeDatabase();
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
