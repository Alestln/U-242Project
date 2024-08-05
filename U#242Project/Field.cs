namespace U_242Project
{
    internal class Field
    {
        private readonly Value[,] _board;

        private readonly Line[] _lines;

        public Field()
        {
            _board = new Value[3, 3];
            InitializeBoard();
            _lines = InitializeLines();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _board[row, col] = new Value();
                }
            }
        }

        private Line[] InitializeLines()
        {
            Line[] lines = new Line[8];
            // Rows
            for (int i = 0; i < 3; i++)
            {
                Value[] rowValues = new Value[3];
                for (int j = 0; j < 3; j++)
                {
                    rowValues[j] = _board[i, j];
                }
                lines[i] = new Line(rowValues);
            }
            // Columns
            for (int i = 0; i < 3; i++)
            {
                Value[] colValues = new Value[3];
                for (int j = 0; j < 3; j++)
                {
                    colValues[j] = _board[j, i];
                }
                lines[i + 3] = new Line(colValues);
            }
            // Diagonals
            Value[] diagonal1 = { _board[0, 0], _board[1, 1], _board[2, 2] };
            lines[6] = new Line(diagonal1);
            Value[] diagonal2 = { _board[0, 2], _board[1, 1], _board[2, 0] };
            lines[7] = new Line(diagonal2);

            return lines;
        }

        public void PlaceSymbol(int row, int col, char symbol)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3)
            {
                throw new ArgumentException("Invalid board position.");
            }

            if (_board[row, col].Symbol != '*')
            {
                throw new InvalidOperationException("This position is already taken.");
            }

            _board[row, col].Symbol = symbol;
        }

        private bool IsBoardFull()
        {
            foreach (var value in _board)
            {
                if (value.Symbol == '*')
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckForWinner(char symbol)
        {
            foreach (var line in _lines)
            {
                if (line.IsWinningLine(symbol))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsGameOver()
        {
            return IsBoardFull() || CheckForWinner('X') || CheckForWinner('O');
        }

        public void DisplayBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(_board[row, col].Symbol + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
