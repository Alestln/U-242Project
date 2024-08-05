using U_242Project;

class HelloWorld
{    
    static void Main()
    {
        Field field = new Field();
        char currentPlayer = 'X';
        bool gameWon = false;

        while (!field.IsGameOver())
        {
            field.DisplayBoard();
            Console.WriteLine($"Player {currentPlayer}'s turn.");

            int row, col;
            while (true)
            {
                Console.Write("Enter row (0, 1, 2): ");
                if (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                    continue;
                }

                Console.Write("Enter column (0, 1, 2): ");
                if (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                    continue;
                }

                try
                {
                    field.PlaceSymbol(row, col, currentPlayer);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (field.CheckForWinner(currentPlayer))
            {
                field.DisplayBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                gameWon = true;
                break;
            }

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';

            Console.Clear();
        }

        if (!gameWon)
        {
            field.DisplayBoard();
            Console.WriteLine("The game is a draw.");
        }
    }
}