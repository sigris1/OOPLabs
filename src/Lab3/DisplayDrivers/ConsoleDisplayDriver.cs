using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public ConsoleDisplayDriver(Color color)
    {
        MyColor = color;
    }

    public void Clear()
    {
        Console.Clear();
    }

    private Color MyColor { get; set; }

    public void ChangeColor(Color color)
    {
        MyColor = color;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.MessageText != null)
            Console.WriteLine(Crayon.Output.Rgb(MyColor.R, MyColor.G, MyColor.B).Text(message.MessageText));
    }
}