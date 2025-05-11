using Itmo.ObjectOrientedProgramming.Lab4.Viewers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Systems;

public interface ISystem
{
    string Path { get; }

    void OpenSystem(string path, string mode);

    void DisconnectSystem();

    void FileCopy(string pathTo, string pathFrom);

    void FileDelete(string path);

    void FileMove(string pathTo, string pathFrom);

    void FileRename(string path, string newName);

    void FileShow(string path, IViewer viewer);

    void TreeGoTo(string path);

    void TreeList(int depth);
}