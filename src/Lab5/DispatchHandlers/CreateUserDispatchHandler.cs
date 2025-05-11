using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class CreateUserDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is CreateUserCommand)
        {
            var service = new CreteUserService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}