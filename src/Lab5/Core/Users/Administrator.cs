using ResultTypes;

namespace Users;

public class Administrator : IUser
{
    public Administrator(int number, string pin)
    {
        Number = number;
        Pin = pin;
        _operations = [];
        Balance = 0;
    }

    public long Number { get; }

    public long Balance { get; private set; }

    public string Pin { get; }

    private readonly string _systemPassword = "postgres";
    private readonly List<string> _operations;

    public ResultType Login(string pin)
    {
        if (Pin != pin)
        {
            return new ResultType.BadResultInvalidPin();
        }

        return new ResultType.GoodResult(Balance, _operations.ToString());
    }

    public ResultType GetAccess(string password)
    {
        if (_systemPassword == password)
        {
            return new ResultType.GoodResult(Balance, _operations.ToString());
        }

        return new ResultType.BadResultWrongAdministratorPassword();
    }

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

    public void RedefineBalance(long amount)
    {
        Balance = amount;
    }
}