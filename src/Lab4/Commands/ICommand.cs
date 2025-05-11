using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public void DoCommand(ISystem system);

    public bool Equals(ICommand? other);
}