using Itmo.ObjectOrientedProgramming.Lab3.Displayes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee : IAddressee
{
    public DisplayAddressee(IDisplay display)
    {
        _display = display;
    }

    private readonly IDisplay _display;

    public ResultType ReceiveMessage(Message message)
    {
        _display.ReceiveMessage(message);

        return new ResultType.GoodResult();
    }
}