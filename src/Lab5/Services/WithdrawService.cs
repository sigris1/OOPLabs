using Commands;
using ResultTypes;
using UserRepository;
using Users;

namespace Service;

public class WithdrawService : IService
{
    public ResultType ProcessCommand(IUser user, ICommand command, UsersRepository usersRepository)
    {
        if (command is not WithdrawCommand current)
        {
            return new ResultType.BadResultWrongCommand();
        }

        Task<IUser?> now = usersRepository.FindUserByUserId(user.Number);
        if (now.Result == null)
        {
            return new ResultType.BadResultNonExistentUser();
        }

        if (current.Amount <= user.Balance)
        {
            _ = usersRepository.UpdateInform(user.Number, user.Balance - current.Amount);
        }

        return user.WithdrawMoney(current.Amount);
    }
}