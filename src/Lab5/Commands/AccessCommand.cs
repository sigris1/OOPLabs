namespace Commands;

public class AccessCommand : ICommand
{
    public AccessCommand(string password)
    {
        Password = password;
    }

    public string Password { get; }
}