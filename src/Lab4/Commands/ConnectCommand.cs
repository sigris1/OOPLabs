using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ConnectCommand(string connectedPath, string connectedMode)
    {
        _path = connectedPath;
        _mode = connectedMode;
    }

    public void DoCommand(ISystem system)
    {
        system.OpenSystem(_path, _mode);
    }

    public bool Equals(ICommand? other)
    {
        if (other is not ConnectCommand)
        {
            return false;
        }

        if (other is ConnectCommand connectCommand)
        {
            return _path == connectCommand._path && _mode == connectCommand._mode;
        }

        return false;
    }

    public ISystem CreateNewSystem()
    {
        if (_mode == "local")
        {
            return new LocalSystem(_path);
        }

        return new LocalSystem(" ");
    }
}