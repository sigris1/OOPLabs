namespace Commands;

public class WithdrawCommand : ICommand
{
    public WithdrawCommand(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; }
}