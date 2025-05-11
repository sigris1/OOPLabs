namespace Itmo.ObjectOrientedProgramming.Lab3;

public class User
{
    private readonly List<UserMessage> _messages = [];

    public ResultType ReceiveMessage(Message message)
    {
        _messages.Add(new UserMessage(message));

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

        return new ResultType.BadResultAddresseeDidntReceiveSuchMessage();
    }

    public int Count => _messages.Count;
}