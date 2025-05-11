using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.WithdrawScenarios;

public class WithdrawScenario : IScenario
{
    public WithdrawScenario(Dispatcher dispatcher, int userId)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Withdraw";

    public void Run(UsersRepository usersRepository)
    {
        int id = AnsiConsole.Ask<int>("Enter your id");
        int amount = AnsiConsole.Ask<int>("Enter amount");

        var command = new WithdrawCommand(amount);

        ResultType result = _dispatcher.Dispatch(id, command, usersRepository);

        if (result is ResultType.BadResultExceedBalance)
        {
            AnsiConsole.Ask<string>("[red]You haven't withdrawed a balance![/]");
        }
        else if (result is ResultType.BadResultNonExistentUser)
        {
            AnsiConsole.Ask<string>("[red]User with that userId doesn't exist![/]");
        }
        else
        {
            AnsiConsole.Ask<string>("[green]Success![/]");
        }
    }
}