using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.DepositScenarios;

public class DepositScenario : IScenario
{
    public DepositScenario(Dispatcher dispatcher, int userId)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Deposit";

    public void Run(UsersRepository usersRepository)
    {
        int id = AnsiConsole.Ask<int>("Enter your id");
        int amount = AnsiConsole.Ask<int>("Enter amount");

        var command = new DepositCommand(amount);

        ResultType result = _dispatcher.Dispatch(id, command, usersRepository);
        if (result is ResultType.BadResultNonExistentUser)
        {
            AnsiConsole.Ask<string>("[red]User with that userId doesn't exist![/]");
        }

        AnsiConsole.Ask<string>("[green]Success![/]");
    }
}