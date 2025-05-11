using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class LoginDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is LoginCommand)
        {
            var service = new LoginService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}