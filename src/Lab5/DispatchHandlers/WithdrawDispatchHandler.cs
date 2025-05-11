using Commands;
using ResultTypes;
using Service;
using UserRepository;
using Users;

namespace DispatchHandlers;

public class WithdrawDispatchHandler : BaseDispatchHandler
{
    public override ResultType? Handle(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is WithdrawCommand)
        {
            var service = new WithdrawService();
            service.ProcessCommand(user, command, usersRepository);
        }

        return null;
    }
}