using CommandDispather;
using Commands;
using ResultTypes;
using Spectre.Console;
using UserRepository;

namespace Scenarios.PossibleScenarios.CreateUserScenarios;

public class CreateUserScenario : IScenario
{
    public CreateUserScenario(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    private readonly Dispatcher _dispatcher;

    public string Name => "Create User";

    public void Run(UsersRepository usersRepository)
    {
        string pin = AnsiConsole.Ask<string>("Enter your pin");

        Task<long> userId = usersRepository.AddInform(pin, 0);

        var command = new CreateUserCommand(userId.Id, pin);

        ResultType result = _dispatcher.Dispatch(userId.Id, command, usersRepository);

        AnsiConsole.Ask<string>("[green]Success![/]");
        AnsiConsole.Ask<string>(userId.Id.ToString() + "  - You'r loggin");
    }
}