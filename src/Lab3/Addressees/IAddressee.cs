namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    public ResultType ReceiveMessage(Message message)
    {
        return new ResultType.GoodResult();
    }
}