using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    private ICollection<ProxyAddressee> _topicAddresses;
    private string _topicName;

    public Topic(ICollection<ProxyAddressee> addresses, string topicName)
    {
        TopicAddress = addresses;
        _topicAddresses = TopicAddress;
        _topicName = topicName;
    }

    public string TopicName
    {
        get
        {
            return _topicName;
        }

        protected set
        {
            ArgumentNullException.ThrowIfNull(value);
            _topicName = value;
        }
    }

    public void AddUser(IAddressee user, int instance)
    {
        _topicAddresses.Add(new ProxyAddressee(user, instance));
    }

    public ICollection<ProxyAddressee>? TopicAddress
    {
        get
        {
            return _topicAddresses;
        }

        private set
        {
            ArgumentNullException.ThrowIfNull(value);
            _topicAddresses = value;
        }
    }

    public ResultType TakeMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(_topicAddresses);
        foreach (ProxyAddressee addressee in _topicAddresses)
        {
            if (addressee.ReceiveMessage(message) is ResultType.BadResultLowMessageImportanceLevel)
            {
                return new ResultType.BadResultLowMessageImportanceLevel();
            }
        }

        return new ResultType.GoodResult();
    }
}