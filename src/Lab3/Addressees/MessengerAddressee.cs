namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : IAddressee
{
    public MessengerAddressee(Messenger messenger)
    {
        _messenger = messenger;
    }

    private readonly Messenger _messenger;

    public ResultType GetMessage(Message message)
    {
        _messenger.ReceiveMessage(message);

        return new ResultType.GoodResult();
    }
}