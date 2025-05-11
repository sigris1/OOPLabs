using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectionHandlers;

public class DisconnectCommandHandler : BaseConnectionCommandHandler
{
    public override ICommand? Handle(string[] input)
    {
        IEnumerator<string> now = input.AsEnumerable().GetEnumerator();
        now.MoveNext();
        if (now.Current != "disconnect")
        {
            return null;
        }

        if (now.MoveNext() is false)
        {
            return new DisconnectCommand();
        }

        throw new Exception("Incorrect command");
    }
}