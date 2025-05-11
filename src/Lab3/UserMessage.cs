namespace Itmo.ObjectOrientedProgramming.Lab3;

public class UserMessage
{
    public UserMessage(Message message)
    {
        Message = message;
    }

    public Message Message { get; }

    public bool IsRead { get; private set; } = false;

    public void ReedMessage()
    {
        IsRead = true;
    }
}