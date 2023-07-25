namespace TicTacToe;

internal class Notice : TuiElement
{
    public string Message { get; set; }
    public Notice(string message)
    {
        Message = message;
    }
    public override void Display()
    {
        throw new NotImplementedException();
    }
}
