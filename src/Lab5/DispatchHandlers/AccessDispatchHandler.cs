using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class AccessDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is AccessCommand)
        {
            var service = new GetAccessService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}