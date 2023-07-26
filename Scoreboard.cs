namespace TicTacToe;

internal class Scoreboard : TuiElement
{
    public int Score1 { get; set; } = 0;
    public int Score2 { get; set; } = 0;
    public override void Display()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"\t   {Score1} : {Score2}   \n");
        Console.ResetColor();
    }
}
