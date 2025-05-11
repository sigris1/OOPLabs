using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var parser = new Parser();
        Console.WriteLine("Подключитесь к системе: ");
        string connectLine = Console.ReadLine() ?? string.Empty;
        var firstCommand = (ConnectCommand)(parser.GetCommand(connectLine) ?? throw new Exception());
        ISystem system = firstCommand.CreateNewSystem();
        while (true)
        {
            Console.WriteLine("> ");
            string input = Console.ReadLine() ?? string.Empty;
            ICommand currentCommand = parser.GetCommand(input) ?? throw new Exception();
            if (currentCommand is DisconnectCommand)
            {
                break;
            }

            currentCommand.DoCommand(system);
        }
    }
}