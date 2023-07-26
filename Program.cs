namespace TicTacToe;

internal class Program
{
    static void Main()
    {
        while (true)
        {
            Title title = new("Tic-Tac-Toe");
            Field field = new();
            Label label = new();
            TuiElement[] tuiElements = { title, field, label };
            byte cellNumber;
            byte playerNumber = 1;

            for (byte turn = 1; turn <= 9;)
            {
                Console.Clear();
                label.Color = ConsoleColor.Gray;
                label.Text = $"[Player {playerNumber}] Select cell: ";
                Render(tuiElements);
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
                            break;
                        case 2:
                            field.SetToCell('O', cellNumber);
                            break;
                    }
                    if (field.IsCompleteVertical ||
                        field.IsCompleteHorizontal ||
                        field.IsCompleteDiagonale)
                    {
                        Console.Clear();
                        label.Color = ConsoleColor.Yellow;
                        label.Text = $"[Notice] Player {playerNumber} won.\n";
                        Render(tuiElements);
                        Wait();
                        break;
                    }
                    else if (turn == 9)
                    {
                        Console.Clear();
                        label.Color = ConsoleColor.Yellow;
                        label.Text = "[Notice] Draw.\n";
                        Render(tuiElements);
                        Wait();
                    }
                    playerNumber = playerNumber == 1 ? (byte)2 : (byte)1;
                    turn++;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    label.Color = ConsoleColor.Red;
                    label.Text = $"[Error] {ex.Message}\n";
                    Render(tuiElements);
                    Wait();
                }
            }
        }
    }
    public static void Wait()
    {
        Console.Write("Press any key...");
        Console.ReadKey();
    }
    public static void Render(TuiElement[] elements)
    {
        foreach (TuiElement element in elements)
        {
            element.Display();
        }
    }
}