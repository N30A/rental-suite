using System.Data;
using Npgsql;

namespace N30A.Suite.Web.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        string connectionString = Helpers.BuildConnectionString();
        Helpers.TryConnection(connectionString);
        
        services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(connectionString));
        return services;
    }
}
