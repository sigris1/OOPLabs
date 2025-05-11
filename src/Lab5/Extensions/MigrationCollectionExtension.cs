using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Migrations;

namespace Extensions;

public static class MigrationCollectionExtension
{
    public static IServiceCollection AddMigrations(this IServiceCollection collection)
    {
        return collection.AddFluentMigratorCore()
            .ConfigureRunner(runner =>
                runner.AddPostgres()
                    .WithGlobalConnectionString("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres")
                    .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
            .AddLogging(logging => logging.AddFluentMigratorConsole());
    }
}