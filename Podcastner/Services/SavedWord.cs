using Microsoft.Data.Sqlite;
using Podcastner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Podcastner.Services
{
    public class SavesWord
    {
        private readonly string connectionString =
       "Data Source=podcastner.db";


        public void AddWord(SavedWord worde)
        {

            if (string.IsNullOrWhiteSpace(worde.Word))
            {
                return;
            }

            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
        CREATE TABLE IF NOT EXISTS SavedWords
        (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Word TEXT,
            Phonetic TEXT,
            PartOfSpeech TEXT,
            Definition TEXT,
            Example TEXT
        );
        """;
            command.ExecuteNonQuery();

            command.CommandText =
            """
    INSERT INTO SavedWords
    (Word, Phonetic, PartOfSpeech, Definition, Example)
    VALUES
    ($Word, $Phonetic, $PartOfSpeech, $Definition, $Example);
    """;

            command.Parameters.Clear();

            command.Parameters.AddWithValue("$Id", worde.Id);
            command.Parameters.AddWithValue("$Word", worde.Word);
            command.Parameters.AddWithValue("$Phonetic", worde.Phonetic);
            command.Parameters.AddWithValue("$PartOfSpeech", worde.PartOfSpeech);
            command.Parameters.AddWithValue("$Definition", worde.Definition);
            command.Parameters.AddWithValue("$Example", worde.Example);


            command.ExecuteNonQuery();
            command.Parameters.Clear();
      
        }


        public List<SavedWord> GetWords()
        {
            List<SavedWord> Words = new();


            using var connection = new SqliteConnection(connectionString);

            connection.Open();


            var command = connection.CreateCommand();

            command.CommandText =
            """
        SELECT *
        FROM SavedWords;
        """;

            using var reader = command.ExecuteReader();


            while (reader.Read())
            {
                Words.Add(new SavedWord
                {
                    Id = reader.GetInt32(0),
                    Word = reader.GetString(1),
                    Phonetic = reader.IsDBNull(2) ? null : reader.GetString(2),
                    PartOfSpeech = reader.GetString(3),
                    Definition = reader.GetString(4),
                    Example = reader.IsDBNull(5) ? null : reader.GetString(5)
                });
            }

            return Words;

        } 

  public void Remove(string word)
        {
            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
        DELETE FROM SavedWords
        WHERE Word = $word;
        """;

            command.Parameters.AddWithValue("$word", word);

            command.ExecuteNonQuery();
        }
    } }
