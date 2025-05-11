using Itmo.ObjectOrientedProgramming.Lab4.SystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IVisitor
{
    IComponent[] Visit(IComponent component);
}