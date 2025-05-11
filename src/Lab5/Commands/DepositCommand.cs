namespace Commands;

public class DepositCommand : ICommand
{
    public DepositCommand(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; }
}