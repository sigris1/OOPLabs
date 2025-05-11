namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyAddressee : IAddressee
{
    public ProxyAddressee(IAddressee address, int importance)
    {
        _address = address;
        _importanceLevel = importance;
    }

    private readonly IAddressee _address;

    private readonly int _importanceLevel;

    public ResultType ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel > _importanceLevel)
        {
            _address.ReceiveMessage(message);
            return new ResultType.GoodResult();
        }

        return new ResultType.BadResultLowMessageImportanceLevel();
    }
}