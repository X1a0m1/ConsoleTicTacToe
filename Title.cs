namespace TicTacToe;

internal class Title : TuiElement
{
    private readonly string _title;
    public Title(string title)
    {
        _title = title.ToUpper();
    }
    public override void Display()
    {
        Console.WriteLine($"\t{_title}\n");
    }
}