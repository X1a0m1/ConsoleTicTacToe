namespace TicTacToe;

internal class Label : TuiElement
{
    public string Text { get; set; } = string.Empty;
    public ConsoleColor Color { get; set; } = ConsoleColor.Gray;
    public override void Display()
    {
        Console.ForegroundColor = Color;
        Console.Write(Text);
        Console.ResetColor();
    }
}
