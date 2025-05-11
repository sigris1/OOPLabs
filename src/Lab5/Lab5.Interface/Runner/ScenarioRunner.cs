using Scenarios;
using Spectre.Console;
using UserRepository;

namespace Runner;

public class ScenarioRunner
{
    private readonly AllScenarios _allScenarios;

    public ScenarioRunner(AllScenarios allScenarios)
    {
        _allScenarios = allScenarios;
    }

    public void Run(UsersRepository usersRepository)
    {
        IEnumerable<IScenario> scenarios = _allScenarios.Scenarios;

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        Console.WriteLine(scenario.Name);
        scenario.Run(usersRepository);
    }
}
