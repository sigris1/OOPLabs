using ResultTypes;

namespace Users;

public class User : IUser
{
    public User(long number, string pin)
    {
        Number = number;
        Pin = pin;
        _operations = [];
        Balance = 0;
    }

    public long Number { get; }

    public string Pin { get; }

    public ResultType Login(string pin)
    {
        if (Pin != pin)
        {
            return new ResultType.BadResultInvalidPin();
        }

        _operations.Add("Login");
        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    private readonly List<string> _operations;

    public long Balance { get; private set; }

    public ResultType GetBalances()
    {
        string line = "Balance: " + string.Join(" ", Balance);
        Console.WriteLine(line);
        _operations.Add("Viewing the balance");
        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    public ResultType WithdrawMoney(int amount)
    {
        if (amount > Balance)
        {
            return new ResultType.BadResultExceedBalance();
        }

        Balance -= amount;
        string line = "Withdraw: " + string.Join(" ", amount);
        _operations.Add(line);
        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    public ResultType DepositMoney(int amount)
    {
        Balance += amount;
        string line = "Deposit: " + string.Join(" ", amount);
        _operations.Add(line);
        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    public ResultType GetOperations()
    {
        foreach (string operation in _operations)
        {
            Console.WriteLine(operation);
        }

        _operations.Add("See all operations");
        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    public ResultType GetAccess(string password)
    {
        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    public void RedefineBalance(long amount)
    {
        Balance = amount;
    }
}