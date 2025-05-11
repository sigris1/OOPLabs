using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.LoginScenarios;

public class LoginAdministratorScenario : IScenario
{
    public LoginAdministratorScenario(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Login Administrator";

    public void Run(UsersRepository usersRepository)
    {
        int userid = AnsiConsole.Ask<int>("Enter your userId");

        string pin = AnsiConsole.Ask<string>("Enter your pin");

        string systemPassword = AnsiConsole.Ask<string>("Enter system password");

        var command = new LoginCommand(pin);
        var secondCommand = new AccessCommand(systemPassword);
        ResultType result = _dispatcher.Dispatch(userid, command, usersRepository);
        ResultType systemPasswordResult = _dispatcher.Dispatch(userid, secondCommand, usersRepository);

        if (result is ResultType.BadResultInvalidPin)
        {
            AnsiConsole.Ask<string>("[red]Invalid pin![/]");
        }
        else
        {
            if (systemPasswordResult is ResultType.BadResultWrongAdministratorPassword)
            {
                AnsiConsole.Ask<string>("[red]Invalid system password![/]");
                System.Environment.Exit(0);
            }
            else if (result is ResultType.BadResultNonExistentUser)
            {
                AnsiConsole.Ask<string>("[red]User with that userId doesn't exist![/]");
            }
            else
            {
                AnsiConsole.Ask<string>("[green]Success!![/]");
            }
        }
    }
}