namespace Itmo.ObjectOrientedProgramming.Lab4.SystemComponents;

public interface IComponent
{
    string Name { get; }

    IComponent[] GoThis();
}