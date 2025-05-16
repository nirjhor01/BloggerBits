using System;
using Npgsql;

namespace BloggerBits.query;

public class DatabaseCommandRunner : IDatabaseCommandRunner
{
    private readonly string _connectionString;

    // Constructor now accepts IConfiguration to read connection string from config
    public DatabaseCommandRunner(IConfiguration configuration)
    {
        // Fetch the connection string from configuration
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Implementing ExecuteCommand from IDatabaseCommandRunner interface
    public string ExecuteCommand(string commandText)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        using (var command = new NpgsqlCommand(commandText, connection))
        {
            // Add parameter to avoid SQL injection
            //command.Parameters.AddWithValue("$1", senderId);

            // Open connection and execute the command
            connection.OpenAsync();
            var result = command.ExecuteScalarAsync();
            connection.CloseAsync();  

            return result?.ToString();  // Return the result or null if no result
        }
    }

}
