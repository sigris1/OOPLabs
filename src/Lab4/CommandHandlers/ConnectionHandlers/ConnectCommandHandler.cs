using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectionHandlers;

public class ConnectCommandHandler : BaseConnectionCommandHandler
{
    private string? _path;
    private string? _mode;

    public override ICommand? Handle(string[] input)
    {
        IEnumerator<string> now = input.AsEnumerable().GetEnumerator();
        now.MoveNext();
        if (now.Current != "connect")
        {
            return null;
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _path = now.Current;
        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        if (now.Current != "-m")
        {
            throw new Exception("Incorrect command");
        }

        if (now.MoveNext() is false)
        {
            throw new Exception("Incorrect command");
        }

        _mode = now.Current;

        if (now.MoveNext() is false)
        {
            return new ConnectCommand(_path, _mode);
        }

        throw new Exception("Incorrect command");
    }
}