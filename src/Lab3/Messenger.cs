namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Messenger
{
    public void ReceiveMessage(Message message)
    {
        Console.WriteLine($"Message received from messenger: {message.MessageText}");
    }
}