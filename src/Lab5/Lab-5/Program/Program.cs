using Extensions;
using FluentMigrator.Runner;
using Itmo.ObjectOrientedProgramming.Lab5;
using Microsoft.Extensions.DependencyInjection;
using Runner;
using Spectre.Console;
using UserRepository;

IServiceCollection collection = new ServiceCollection();

collection
    .AddFluentMigratorCore()
    .AddScenarios()
    .ConfigureRunner(runner => runner
        .AddPostgres()
        .WithGlobalConnectionString("Host=localhost;Port=5432;Username=sigris;Password=postgres;Database=postgres")
        .ScanIn(typeof(Migrations.InitialMigration).Assembly).For.Migrations())
    .Configure<FluentMigrator.Runner.Processors.SelectingProcessorAccessorOptions>(options =>
    {
        options.ProcessorId = "Postgres";
    })
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 5432;
        configuration.Username = "sigris";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
        configuration.EnableConnectionProviderLogging = false;
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();
var tryer = new UsersTryer();
ScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<ScenarioRunner>();
UsersRepository userRepository = scope.ServiceProvider.GetRequiredService<UsersRepository>();

while (true)
{
    string choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Select an action")
            .AddChoices("LoginUser", "LoginAdmin", "CreateUser"));
    await tryer.DoChoice(choice, userRepository, scenarioRunner).ConfigureAwait(false);
}