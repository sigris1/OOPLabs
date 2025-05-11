using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace Service;

public class CreteUserService : IService
{
    public ResultType ProcessCommand(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is not CreateUserCommand current)
        {
            return new ResultType.BadResultWrongCommand();
        }

        Task<long> currentId = usersRepository.AddInform(current.UserPin, 0);

        IUser now = new User(currentId.Result, current.UserPin);
        _ = usersRepository.AddInform(current.UserPin, 0);
        return new ResultType.GoodResult(0, "Crete User");
    }
}