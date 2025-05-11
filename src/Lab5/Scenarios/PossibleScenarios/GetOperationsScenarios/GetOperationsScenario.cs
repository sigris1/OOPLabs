using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.GetOperationsScenarios;

public class GetOperationsScenario : IScenario
{
    public GetOperationsScenario(Dispatcher dispatcher, int userId)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Get Operations";

    public void Run(UsersRepository usersRepository)
    {
        int id = AnsiConsole.Ask<int>("Enter your id");
        var command = new GetOperationsCommand();

        ResultType result = _dispatcher.Dispatch(id, command, usersRepository);
        if (result is ResultType.GoodResult)
        {
            var goodResult = result as ResultType.GoodResult;
            AnsiConsole.Ask<string>("[green]Success![/]");
            if (goodResult != null)
            {
                if (goodResult.Operations != null)
                    AnsiConsole.Ask<string>(goodResult.Operations.ToString() + " - Operations");
            }
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