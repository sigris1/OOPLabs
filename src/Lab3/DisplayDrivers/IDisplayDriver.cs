using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public interface IDisplayDriver
{
    public void Clear();

    public void ChangeColor(Color color);

    public void ReceiveMessage(Message message);
}