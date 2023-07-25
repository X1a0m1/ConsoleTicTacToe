namespace TicTacToe;

public readonly struct Title
{
    private readonly string _title;
    public Title(string title)
    {
        _title = title.ToUpper();
    }
    public readonly void Display()
    {
        Console.WriteLine($"\t{_title}\n");
    }
}