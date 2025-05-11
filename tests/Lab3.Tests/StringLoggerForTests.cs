using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;

namespace Lab3.Tests;

public class StringLoggerForTests : ILogger
{
    public string Log { get; private set; } = string.Empty;

    public void LogMessage(Message message)
    {
        Log += message.MessageText;
    }
}