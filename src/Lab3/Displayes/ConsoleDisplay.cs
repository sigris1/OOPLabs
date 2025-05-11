using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displayes;

public class ConsoleDisplay : IDisplay
{
    public ConsoleDisplay(Color color)
    {
        myColor = color;
    }

    private Color myColor;

    public void ChangeColor(Color color)
    {
        myColor = color;
    }

    public void ReceiveMessage(Message message)
    {
        Console.Clear();
        if (message.MessageText != null)
            Console.WriteLine(Crayon.Output.Rgb(myColor.R, myColor.G, myColor.B).Text(message.MessageText));
    }
}