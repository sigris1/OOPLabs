using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class GetOperationsDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is GetOperationsCommand)
        {
            var service = new GetOperationsService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}