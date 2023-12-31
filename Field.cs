﻿namespace TicTacToe;

internal class Field : TuiElement
{
    private char[] _charArray = new char[] {
        '1', '2', '3',
        '4', '5', '6',
        '7', '8', '9' };
    public bool IsCompleteDiagonale
    {
        get
        {
            return (_charArray[0] == _charArray[4] && _charArray[4] == _charArray[8]) ||
                   (_charArray[6] == _charArray[4] && _charArray[4] == _charArray[2]);
        }
    }
    public bool IsCompleteHorizontal
    {
        get
        {
            return (_charArray[0] == _charArray[1] && _charArray[1] == _charArray[2]) ||
                   (_charArray[3] == _charArray[4] && _charArray[4] == _charArray[5]) ||
                   (_charArray[6] == _charArray[7] && _charArray[7] == _charArray[8]);
        }
    }
    public bool IsCompleteVertical
    {
        get
        {
            return (_charArray[0] == _charArray[3] && _charArray[3] == _charArray[6]) ||
                   (_charArray[1] == _charArray[4] && _charArray[4] == _charArray[7]) ||
                   (_charArray[2] == _charArray[5] && _charArray[5] == _charArray[8]);
        }
    }
    public void Clear()
    {
        for (byte index = 0; index < _charArray.Length; index++)
        {
            _charArray[index] = Convert.ToChar((index + 1).ToString());
        }
    }
    public void FillCell(char value, byte index)
    {
        if (value == 'X' || value == 'O')
        {
            if (_charArray[index] != 'X' && _charArray[index] != 'O')
            {
                _charArray[index] = value;
            }
            else
            {
                throw new ArgumentException("Cell is already occupied");
            }
        }
        else
        {
            throw new ArgumentException("Invalid cell value.");
        }
    }
    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\t {_charArray[0]} | {_charArray[1]} | {_charArray[2]}");
        Console.WriteLine("\t---+---+---");
        Console.WriteLine($"\t {_charArray[3]} | {_charArray[4]} | {_charArray[5]}");
        Console.WriteLine("\t---+---+---");
        Console.WriteLine($"\t {_charArray[6]} | {_charArray[7]} | {_charArray[8]}\n");
        Console.ResetColor();
    }
}