namespace TicTacToe;

internal class Program
{
    static void Main()
    {
        // TUI Elements
        Title title = new("Tic-Tac-Toe");
        Scoreboard scoreboard = new();
        Field field = new();
        Label label = new();
        TuiElement[] tuiElements = { title, scoreboard, field, label };

        // Players
        Player[] players = { new('X'), new('O') };
        Player player; // Current player

        // Datas
        byte cellNumber;

        // Main cycle
        while (true)
        {
            field.Clear();
            // Update counters
            scoreboard.LeftCounter = players[0].Score;
            scoreboard.RightCounter = players[1].Score;

            // Round cycle
            for (byte turn = 1; turn <= 9;)
            {
                player = turn % 2 != 0 ? players[0] : players[1];

                Console.Clear();
                label.Color = ConsoleColor.Gray;
                label.Text = $"[Player {player.Number}] Select cell: ";
                Render(tuiElements);
                try
                {
                    cellNumber = Convert.ToByte(Console.ReadLine());
                    cellNumber--;
                    if ((cellNumber > 8) || (cellNumber < 0))
                    {
                        throw new ArgumentOutOfRangeException("Сell with this number does not exist.");
                    }
                    field.FillCell(player.Char, cellNumber);

                    // Win check
                    if (field.IsCompleteVertical ||
                        field.IsCompleteHorizontal ||
                        field.IsCompleteDiagonale)
                    {
                        Console.Clear();
                        label.Color = ConsoleColor.Yellow;
                        label.Text = $"[Notice] Player {player.Number} won.\n";
                        Render(tuiElements);
                        Wait();
                        player.Score++;
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