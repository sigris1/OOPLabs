using ResultTypes;
using Users;

namespace Services;

public class WorkService
{
    public ResultType CreateUser(int userId, string userPin)
    {
        IUser current = new User(userId, userPin);
        return new ResultType.GoodResult();
    }

    public ResultType DepositMoney(IUser currentUser, int amount)
    {
        return currentUser.DepositMoney(amount);
    }

    public ResultType WithdrawMoney(IUser currentUser, int amount)
    {
        return currentUser.WithdrawMoney(amount);
    }

    public ResultType GetBalance(IUser currentUser)
    {
        return currentUser.GetBalance();
    }

    public ResultType GetOperations(IUser currentUser)
    {
        return currentUser.GetOperations();
    }

    public ResultType GetAccess(Administrator currentAdministrator, string currentPassword)
    {
        return currentAdministrator.GetAccess(currentPassword);
    }
}