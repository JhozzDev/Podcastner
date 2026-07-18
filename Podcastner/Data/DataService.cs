using Microsoft.Data.Sqlite;

namespace Podcastner.Data;

public class DatabaseService
{
    private readonly string connectionString =
        "Data Source=podcastner.db";


    public void Initialize()
    {
        using var connection = new SqliteConnection(connectionString);

        connection.Open();


        var command = connection.CreateCommand();

        command.CommandText =
        """
        CREATE TABLE IF NOT EXISTS Favorites
        (
            Uuid TEXT PRIMARY KEY,
            Name TEXT NOT NULL,
            Description TEXT,
            ImageUrl TEXT
        );
        """;


        command.ExecuteNonQuery();
    }
}