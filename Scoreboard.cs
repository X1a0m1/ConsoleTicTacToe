namespace TicTacToe;

internal class Scoreboard : TuiElement
{
    public short LeftCounter { get; set; }
    public short RightCounter { get; set; }
    public override void Display()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"\t   {LeftCounter} : {RightCounter}   \n");
        Console.ResetColor();
    }
}
