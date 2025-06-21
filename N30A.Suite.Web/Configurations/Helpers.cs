using Npgsql;

namespace N30A.Suite.Web.Configurations;

public static class Helpers
{   
    private static string GetEnvironmentVariableOrThrow(string key)
    {
        string? value = Environment.GetEnvironmentVariable(key);
        if (string.IsNullOrWhiteSpace(value))
        {   
            throw new InvalidOperationException($"Environment variable '{key}' is required but was not found.");
        }
        return value;
    }
    
    public static string BuildConnectionString()
    {
        string host = GetEnvironmentVariableOrThrow("DB_HOST");
        string database = GetEnvironmentVariableOrThrow("DB_DATABASE");
        string user = GetEnvironmentVariableOrThrow("DB_USER");
        string password = GetEnvironmentVariableOrThrow("DB_PASSWORD");
        
        return $"Host={host};Username={user};Password={password};Database={database}";
    }
    
    public static void TryConnection(string connectionString)
    {
        try
        {   
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }
        catch (Exception ex)
        {  
            throw new InvalidOperationException($"Could not connect to database '{connectionString}'.", ex);
        }
    }
}
