using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.LoginScenarios;

public class LoginUserScenario : IScenario
{
    public LoginUserScenario(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Login User";

    public void Run(UsersRepository usersRepository)
    {
        long userid = AnsiConsole.Ask<long>("Enter your userId");

        string pin = AnsiConsole.Ask<string>("Enter your pin");

        var command = new LoginCommand(pin);

        ResultType result = _dispatcher.Dispatch(userid, command, usersRepository);
        if (result is ResultType.BadResultInvalidPin)
        {
            AnsiConsole.Ask<string>("[red]Invalid pin![/]");
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