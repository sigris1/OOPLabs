using Runner;
using Spectre.Console;
using UserRepository;
using IUser = Users.IUser;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public class UsersTryer
{
    public async Task<bool> TryLoginUser(UsersRepository userRepository)
    {
        long userId = AnsiConsole.Ask<long>("Enter your userId: ");
        string pin = AnsiConsole.Ask<string>("Enter your pin: ");

        IUser? user = await userRepository.FindUserByUserId(userId).ConfigureAwait(false);

        if (user == null || user.Pin != pin)
        {
            AnsiConsole.MarkupLine("[red]Invalid user or pin![/]");
            return false;
        }

        AnsiConsole.MarkupLine("[green]Login successful![/]");
        return true;
    }

    public async Task<bool> TryLoginAdmin(UsersRepository userRepository)
    {
        long adminId = AnsiConsole.Ask<long>("Enter admin userId: ");
        string pin = AnsiConsole.Ask<string>("Enter your pin: ");
        string password = AnsiConsole.Ask<string>("Enter system password: ");

        Users.IUser? admin = await userRepository.FindUserByUserId(adminId).ConfigureAwait(false);

        if (admin == null || admin.Pin != pin || password != "postgres")
        {
            AnsiConsole.MarkupLine("[red]Invalid admin credentials![/]");
            return false;
        }

        AnsiConsole.MarkupLine("[green]Admin login successful![/]");
        return true;
    }

    public async Task TryCreateUser(UsersRepository userRepository)
    {
        string pin = AnsiConsole.Ask<string>("Enter new pin: ");
        long balance = AnsiConsole.Ask<long>("Enter starting balance: ");

        await userRepository.AddInform(pin, balance).ConfigureAwait(false);

        AnsiConsole.MarkupLine("[green]User created successfully![/]");
    }

    public async Task DoChoice(string choice, UsersRepository userRepository, ScenarioRunner scenarioRunner)
    {
        switch (choice)
        {
            case "LoginUser":
            {
                bool loginSuccess = await TryLoginUser(userRepository).ConfigureAwait(false);
                if (loginSuccess)
                {
                    AnsiConsole.MarkupLine("Now you can choose other scenarios!");
                    scenarioRunner.Run(userRepository);
                }

                break;
            }

            case "LoginAdmin":
            {
                bool adminLoginSuccess = await TryLoginAdmin(userRepository).ConfigureAwait(false);
                if (adminLoginSuccess)
                {
                    AnsiConsole.MarkupLine("Now you can choose other scenarios!");
                    scenarioRunner.Run(userRepository);
                }

                break;
            }

            case "CreateUser":
            {
                await TryCreateUser(userRepository).ConfigureAwait(false);
                break;
            }
        }
    }
}