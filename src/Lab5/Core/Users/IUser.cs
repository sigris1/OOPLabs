using ResultTypes;

namespace Users;

public interface IUser
{
    long Number { get; }

    long Balance { get; }

    string Pin { get; }

    ResultType Login(string pin);

    ResultType GetBalances();

    ResultType WithdrawMoney(int amount);

    ResultType DepositMoney(int amount);

    ResultType GetOperations();

    ResultType GetAccess(string password);

    void RedefineBalance(long amount);
}