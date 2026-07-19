using Microsoft.Data.Sqlite;
using Podcastner.Models;

namespace Podcastner.Services;

public class FavoriteService
{
    private readonly string connectionString =
        "Data Source=podcastner.db";


    public void Add(FavoritePodcast podcast)
    {

        if (string.IsNullOrWhiteSpace(podcast.Uuid))
            return;

        using var connection = new SqliteConnection(connectionString);

        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText =
        """
        INSERT OR REPLACE INTO Favorites
        VALUES
        ($uuid,$name,$description,$image);
        """;

        command.Parameters.AddWithValue("$uuid", podcast.Uuid);
        command.Parameters.AddWithValue("$name", podcast.Name);
        command.Parameters.AddWithValue("$description", podcast.Description);
        command.Parameters.AddWithValue("$image", podcast.ImageUrl);

        command.ExecuteNonQuery();
    }


    public void Remove(string uuid)
    {
        using var connection = new SqliteConnection(connectionString);

        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText =
        """
        DELETE FROM Favorites
        WHERE Uuid = $uuid;
        """;

        command.Parameters.AddWithValue("$uuid", uuid);

        command.ExecuteNonQuery();
    }


    public bool Exists(string uuid)
    {
        using var connection = new SqliteConnection(connectionString);

        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText =
        """
        SELECT COUNT(*)
        FROM Favorites
        WHERE Uuid = $uuid;
        """;

        command.Parameters.AddWithValue("$uuid", uuid);

        long count = (long)command.ExecuteScalar();

        return count > 0;
    }


    public List<FavoritePodcast> GetFavorites()
    {
        List<FavoritePodcast> favorites = new();


        using var connection = new SqliteConnection(connectionString);

        connection.Open();


        var command = connection.CreateCommand();

        command.CommandText =
        """
        SELECT Uuid, Name, Description, ImageUrl
        FROM Favorites;
        """;


        using var reader = command.ExecuteReader();


        while (reader.Read())
        {
            favorites.Add(new FavoritePodcast
            {
                Uuid = reader.GetString(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                ImageUrl = reader.GetString(3)
            });
        }


        return favorites;
    }
}