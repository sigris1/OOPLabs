namespace Itmo.ObjectOrientedProgramming.Lab4.Viewers;

public class ConsoleViewer : IViewer
{
    public void ObserveInformationFromFile(string filePath)
    {
        Console.WriteLine(File.ReadAllText(filePath));
    }
}