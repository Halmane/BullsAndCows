using System.Drawing;

namespace BullsAndCows;

public class ChangeConsoleColor : IDisposable
{
    private ConsoleColor _color;
    public ChangeConsoleColor(ConsoleColor color)
    {
        _color = Console.BackgroundColor;
        Console.BackgroundColor = color;
    }

    public void Dispose()
    {
        Console.BackgroundColor = _color;
    }
}
