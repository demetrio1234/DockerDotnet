using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {

        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

        string connectionString = "Data Source=database.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            // Example: Create a table
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
            ";
            command.ExecuteNonQuery();

            Console.WriteLine("Database connected and table created (if not exists).");
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=databse.dat");
    }
}