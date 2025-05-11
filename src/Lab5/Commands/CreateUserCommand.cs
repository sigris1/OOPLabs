namespace Commands;

public class CreateUserCommand : ICommand
{
    public CreateUserCommand(int id, string pin)
    {
        UserId = id;
        UserPin = pin;
    }

    public int UserId { get; }

    public string UserPin { get; }
}