using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace Service;

public class DepositService : IService
{
    public ResultType ProcessCommand(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is not DepositCommand current)
        {
            return new ResultType.BadResultWrongCommand();
        }

        Task<IUser?> now = usersRepository.FindUserByUserId(user.Number);
        if (now.Result == null)
        {
            return new ResultType.BadResultNonExistentUser();
        }

        _ = usersRepository.UpdateInform(user.Number, current.Amount + user.Balance);
        return user.DepositMoney(current.Amount);
    }
}