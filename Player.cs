namespace TicTacToe;

internal class Player
{
    private static byte _number = 0;
    public byte Number { get; private set; }
    public char Char { get; set; }
    public short Score { get; set; } = 0;
    public Player(char _char)
    {
        Char = _char;
        _number++;
        Number = _number;
    }
}