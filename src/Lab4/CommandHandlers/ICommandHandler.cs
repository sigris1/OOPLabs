using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public interface ICommandHandler
{
    ICommandHandler AddNext(ICommandHandler commandHandler);

    ICommand? Handle(string[] input);
}