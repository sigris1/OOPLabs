using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public void DoCommand(ISystem system)
    {
        system.DisconnectSystem();
    }

    public bool Equals(ICommand? other)
    {
        if (other is not DisconnectCommand)
        {
            return false;
        }

        if (other is DisconnectCommand disconnectCommand)
        {
            return true;
        }

        return false;
    }
}