using Itmo.ObjectOrientedProgramming.Lab4.SystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Viewers;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public class LocalSystem : ISystem
{
    public string Path { get; private set; }

    public LocalSystem(string path)
    {
        Path = path;
    }

    public void OpenSystem(string path, string mode)
    {
        Path = path;
    }

    public void DisconnectSystem()
    {
        Path = string.Empty;
    }

    public void FileCopy(string pathTo, string pathFrom)
    {
        string currentPathFrom = Path + pathFrom;
        if (!File.Exists(currentPathFrom))
        {
            currentPathFrom = pathFrom;
        }

        string currentPathTo = Path + pathTo;
        if (!File.Exists(currentPathTo))
        {
            currentPathFrom = pathTo;
        }

        File.Copy(currentPathFrom, currentPathTo, true);
    }

    public void FileDelete(string path)
    {
        string currentPath = Path + path;
        if (File.Exists(currentPath))
        {
            File.Delete(currentPath);
        }
        else
        {
            File.Delete(path);
        }
    }

    public void FileMove(string pathTo, string pathFrom)
    {
        string currentPathFrom = Path + pathFrom;
        if (!File.Exists(currentPathFrom))
        {
            currentPathFrom = pathFrom;
        }

        string currentPathTo = Path + pathTo;
        if (!File.Exists(currentPathTo))
        {
            currentPathFrom = pathTo;
        }

        File.Move(currentPathFrom, currentPathTo, true);
    }

    public void FileRename(string path, string newName)
    {
        string currentPath = Path + path;
        if (!File.Exists(currentPath))
        {
            currentPath = path;
        }

        File.Move(currentPath, newName);
        File.Delete(currentPath);
    }

    public void FileShow(string path, IViewer viewer)
    {
        viewer.ObserveInformationFromFile(path);
    }

    public void TreeGoTo(string path)
    {
        string currentPath = Path + path;
        if (File.Exists(currentPath))
        {
            Path = currentPath;
        }
        else
        {
           Path = path;
        }
    }

    public void TreeList(int depth)
    {
        var visitor = new ConsoleVisitor(depth);
        var directory = new LocalDirectory(Path);
        visitor.VisitToDepth(directory, depth);
    }
}