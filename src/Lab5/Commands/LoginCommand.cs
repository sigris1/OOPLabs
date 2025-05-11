namespace Commands;

public class LoginCommand : ICommand
{
    public LoginCommand(string pin)
    {
        Pin = pin;
    }

    public string Pin { get; }
}