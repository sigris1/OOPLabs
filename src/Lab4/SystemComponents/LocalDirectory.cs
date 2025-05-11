namespace Itmo.ObjectOrientedProgramming.Lab4.SystemComponents;

public class LocalDirectory : IComponent
{
    public string Name { get; }

    public LocalDirectory(string name)
    {
        Name = name;
    }

    public IComponent[] GoThis()
    {
        List<IComponent> components = [];
        components.AddRange(this.GetFiles());
        return components.ToArray();
    }

    public IReadOnlyList<IComponent> GetFiles()
    {
        string[] names = Directory.GetFileSystemEntries(Name);
        List<IComponent> returned = [];

        foreach (string name in names)
        {
            if (Directory.Exists(name))
            {
                returned.Add(new LocalDirectory(name));
            }

            if (File.Exists(name))
            {
                returned.Add(new LocalFile(name));
            }
        }

        return returned;
    }
}