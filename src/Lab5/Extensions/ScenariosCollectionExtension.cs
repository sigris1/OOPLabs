using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Runner;
using UserRepository;

namespace Extensions;

public static class ScenariosCollectionExtension
{
    public static IServiceCollection AddScenarios(this IServiceCollection collection)
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";
        collection.AddSingleton(new NpgsqlConnection(connectionString));
        collection.AddScoped<UsersRepository>();
        collection.AddTransient<ScenarioRunner>();
        return collection;
    }
}