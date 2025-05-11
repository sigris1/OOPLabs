using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class GetBalanceDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is GetBalanceCommand)
        {
            var service = new GetBalanceService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}