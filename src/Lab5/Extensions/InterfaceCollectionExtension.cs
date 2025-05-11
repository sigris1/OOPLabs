using CommandDispather;
using Microsoft.Extensions.DependencyInjection;
using Runner;
using Scenarios;
using Scenarios.PossibleScenarios.CreateUserScenarios;
using Scenarios.PossibleScenarios.DepositScenarios;
using Scenarios.PossibleScenarios.GetBalanceScenarios;
using Scenarios.PossibleScenarios.GetOperationsScenarios;
using Scenarios.PossibleScenarios.LoginScenarios;
using Scenarios.PossibleScenarios.WithdrawScenarios;

namespace Extensions;

public static class InterfaceCollectionExtension
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        var dispatcher = new Dispatcher();
        collection.AddScoped<Dispatcher, Dispatcher>();
        collection.AddSingleton<IScenario>(provider => new CreateUserScenario(dispatcher));
        collection.AddSingleton<IScenario>(provider => new DepositScenario(dispatcher, 0));
        collection.AddSingleton<IScenario>(provider => new GetBalanceScenario(dispatcher, 0));
        collection.AddSingleton<IScenario>(provider => new GetOperationsScenario(dispatcher, 0));
        collection.AddSingleton<IScenario>(provider => new LoginUserScenario(dispatcher));
        collection.AddSingleton<IScenario>(provider => new LoginAdministratorScenario(dispatcher));
        collection.AddSingleton<IScenario>(provider => new WithdrawScenario(dispatcher, 0));
        collection.AddSingleton<AllScenarios>();
        return collection;
    }
}