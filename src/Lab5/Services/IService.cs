using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace Service;

public interface IService
{
    public ResultType ProcessCommand(IUser user, ICommand command, UsersRepository usersRepository);
}