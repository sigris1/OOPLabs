using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class DepositDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is DepositCommand)
        {
            var service = new DepositService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}