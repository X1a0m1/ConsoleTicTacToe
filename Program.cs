namespace TicTacToe;

internal class Program
{
    static void Main()
    {
        Title title = new("Tic-Tac-Toe");
        Field field = new();
        byte cellNumber;
        byte playerNumber = 1;

        for (byte turn = 1; turn <= 9;)
        {
            Console.Clear();
            title.Display();
            field.Display();
            Console.Write($"[Player {playerNumber}] Select cell: ");
            try
            {
                cellNumber = Convert.ToByte(Console.ReadLine());
                cellNumber--;
                if ((cellNumber > 8) || (cellNumber < 0))
                {
                    throw new ArgumentException("Сell with this number does not exist.");
                }
                switch (playerNumber)
                {
                    case 1:
                        field.SetToCell('X', cellNumber);
                        playerNumber = 2;
                        break;
                    case 2:
                        field.SetToCell('O', cellNumber);
                        playerNumber = 1;
                        break;
                    default:
                        throw new Exception("Unknown Exception.");
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                title.Display();
                field.Display();
                Error(ex.Message);
            }
            if (field.IsCompleteVertical ||
                    field.IsCompleteHorizontal ||
                    field.IsCompleteDiagonale)
            {
                Console.Clear();
                title.Display();
                field.Display();
                Notice($"Player {playerNumber} won.");
                break;
            }
            else if (turn == 9)
            {
                Console.Clear();
                field.Display();
                title.Display();
                Notice("Draw.");
            }
            turn++;
        }
        Main();
    }
    public static void Wait()
    {
        Console.Write("Press any key...");
        Console.ReadKey();
    }
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[Error]: {message}");
        Console.ResetColor();
        Wait();
    }
    public static void Notice(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[Notice]: {message}");
        Console.ResetColor();
        Wait();
    }
}