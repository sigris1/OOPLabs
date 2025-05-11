using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace Service;

public class GetOperationsService : IService
{
    public ResultType ProcessCommand(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is not GetOperationsCommand current)
        {
            return new ResultType.BadResultWrongCommand();
        }

        Task<IUser?> now = usersRepository.FindUserByUserId(user.Number);
        if (now.Result == null)
        {
            return new ResultType.BadResultNonExistentUser();
        }

        return user.GetOperations();
    }
}