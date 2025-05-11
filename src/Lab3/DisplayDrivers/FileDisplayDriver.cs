using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver
{
    public FileDisplayDriver(string filePath, Color color)
    {
        _filePath = filePath;
        MyColor = color;
    }

    private readonly string _filePath;

    public void Clear()
    {
        File.AppendAllText(_filePath, string.Empty);
    }

    private Color MyColor { get; set; }

    public void ChangeColor(Color color)
    {
        MyColor = color;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.MessageText != null)
            File.AppendText(_filePath).WriteLine(Crayon.Output.Rgb(MyColor.R, MyColor.G, MyColor.B).Text(message.MessageText));
    }
}