namespace Itmo.ObjectOrientedProgramming.Lab4.SystemComponents;

public class LocalFile : IComponent
{
    public string Name { get; }

    public LocalFile(string name)
    {
        Name = name;
    }

    public IComponent[] GoThis()
    {
        return new[] { this };
    }
}