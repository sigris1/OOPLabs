using Itmo.ObjectOrientedProgramming.Lab4.SystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public class ConsoleVisitor : IVisitor
{
    private readonly int _depth;

    public ConsoleVisitor(int depth)
    {
        _depth = depth;
    }

    public IComponent[] Visit(IComponent component)
    {
       return component.GoThis();
    }

    public void VisitToDepth(IComponent component, int depth)
    {
        foreach (IComponent currentComponent in component.GoThis())
        {
            if (currentComponent is LocalFile)
            {
                string s = string.Concat(Enumerable.Repeat("    ", _depth - depth));
                Console.WriteLine(s + currentComponent.Name);
            }

            if (currentComponent is LocalDirectory)
            {
                string s = string.Concat(Enumerable.Repeat("    ", _depth - depth));
                Console.WriteLine(s + currentComponent.Name);
                VisitToDepth(currentComponent, depth - 1);
            }
        }
    }
}