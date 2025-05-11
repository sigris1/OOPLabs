namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class ConsoleLogger : ILogger
{
    public void LogMessage(Message message)
    {
        Console.WriteLine(message.MessageText);
    }
}