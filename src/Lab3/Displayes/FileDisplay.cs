using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displayes;

public class FileDisplay : IDisplay
{
    public FileDisplay(string filePath, Color color)
    {
        _filePath = filePath;
        myColor = color;
    }

    private readonly string _filePath;

    private Color myColor;

    public void ChangeColor(Color color)
    {
        myColor = color;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.MessageText != null)
            File.WriteAllText(_filePath, Crayon.Output.Rgb(myColor.R, myColor.G, myColor.B).Text(message.MessageText));
    }
}