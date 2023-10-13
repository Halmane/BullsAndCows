using System.Drawing;

namespace BullsAndCows;

public class ChangeConsoleColor : IDisposable
{
    public ChangeConsoleColor(ConsoleColor color)
    {
        Console.BackgroundColor = color;
    }

    public void Dispose()
    {
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
