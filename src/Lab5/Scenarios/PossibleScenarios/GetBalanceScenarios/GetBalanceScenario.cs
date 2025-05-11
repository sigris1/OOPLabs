using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.GetBalanceScenarios;

public class GetBalanceScenario : IScenario
{
    public GetBalanceScenario(Dispatcher dispatcher, int userId)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Get Balance";

    public void Run(UsersRepository usersRepository)
    {
        int id = AnsiConsole.Ask<int>("Enter your id");
        var command = new GetBalanceCommand();

        ResultType result = _dispatcher.Dispatch(id, command, usersRepository);
        if (result is ResultType.GoodResult)
        {
            var goodResult = result as ResultType.GoodResult;
            AnsiConsole.Ask<string>("[green]Success![/]");
            if (goodResult != null) AnsiConsole.Ask<string>(goodResult.Balance.ToString() + " - Balance");
        }
        else if (result is ResultType.BadResultNonExistentUser)
        {
            AnsiConsole.Ask<string>("[red]User with that userId doesn't exist![/]");
        }
        else
        {
            AnsiConsole.Ask<string>("[red]Error![/]");
        }
    }
}