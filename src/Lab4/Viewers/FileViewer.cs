namespace Itmo.ObjectOrientedProgramming.Lab4.Viewers;

public class FileViewer : IViewer
{
    private readonly string _fileName;

    public FileViewer(string fileName)
    {
        _fileName = fileName;
    }

    public void ObserveInformationFromFile(string filePath)
    {
        File.WriteAllText(_fileName, File.ReadAllText(filePath));
    }
}