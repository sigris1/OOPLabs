using Itmo.ObjectOrientedProgramming.Lab3.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : IAddressee
{
    public UserAddressee(User user, ILogger logger)
    {
        _user = user;
        Logger = logger;
    }

    private readonly User _user;

    private ILogger Logger { get; }

    private readonly List<UserMessage> _messages = [];

    public ResultType ReceiveMessage(Message message)
    {
        _messages.Add(new UserMessage(message));

        _user.ReceiveMessage(message);

        return new ResultType.GoodResult();
    }

    public ResultType ReadMessage(Message message)
    {
        foreach (UserMessage nowMessage in _messages)
        {
            if (nowMessage.Message == message)
            {
                if (nowMessage.IsRead)
                {
                    return new ResultType.BadResultMessageAlreadyHasBeenRead();
                }

                nowMessage.ReedMessage();
                return new ResultType.GoodResult();
            }
        }

        DoLog(message);

        return new ResultType.BadResultAddresseeDidntReceiveSuchMessage();
    }

    public void DoFilter()
    {
        _messages.Sort((x, y) => x.Message.ImportanceLevel.CompareTo(y.Message.ImportanceLevel));
    }

    public void DoLog(Message message)
    {
        Logger.LogMessage(message);
    }
}