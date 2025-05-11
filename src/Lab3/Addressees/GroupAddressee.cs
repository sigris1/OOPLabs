using Itmo.ObjectOrientedProgramming.Lab3.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : IAddressee
{
    public GroupAddressee(ICollection<IAddressee> addresses, ILogger logger)
    {
        _addresses = addresses;
        _logger = logger;
    }

    private readonly ILogger _logger;

    private readonly ICollection<IAddressee> _addresses;

    private readonly List<Message> _messages = [];

    public ResultType ReceiveMessage(Message message)
    {
        _messages.Add(message);

        foreach (IAddressee addressee in _addresses)
        {
            if (addressee.ReceiveMessage(message) is not ResultType.GoodResult)
            {
                return addressee.ReceiveMessage(message);
            }
        }

        DoLog(message);

        return new ResultType.GoodResult();
    }

    public void DoFilter()
    {
        _messages.Sort((x, y) => x.ImportanceLevel.CompareTo(y.ImportanceLevel));
    }

    public void DoLog(Message message)
    {
        _logger.LogMessage(message);
    }
}