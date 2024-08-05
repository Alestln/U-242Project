namespace U_242Project
{
    internal class Board
    {
        private readonly Value[,] _values;
        private readonly Line[] _lines;

        public Board()
        {
            _values = new Value[3, 3];
            InitializeValues();
            _lines = InitializeLines();
        }

        private void InitializeValues()
        {
            for (int i = 0; i < _values.GetLength(0); i++)
            {
                for (int j = 0; j < _values.GetLength(1); j++)
                {
                    _values[i, j] = new Value();
                }
            }
        }

        private Line[] InitializeLines()
        {
            var lines = new Line[_values.GetLength(0) + _values.GetLength(1) + 2];

            // Rows
            for (var i = 0; i < _values.GetLength(0); i++)
            {
                var rowValues = new Value[_values.GetLength(0)];
                for (var j = 0; j < rowValues.Length; j++)
                {
                    rowValues[j] = _values[i, j];
                }
                lines[i] = new Line(rowValues);
            }

            // Columns
            for (var i = 0; i < _values.GetLength(1); i++)
            {
                var colValues = new Value[_values.GetLength(1)];
                for (var j = 0; j < colValues.Length; j++)
                {
                    colValues[j] = _values[i, j];
                }
                lines[i + _values.GetLength(0)] = new Line(colValues);
            }

            // Main diagonal
            var mainDiagonal = new Value[_values.GetLength(0)];
            for (var i = 0; i < mainDiagonal.Length; i++)
            {
                mainDiagonal[i] = _values[i, i];
            }
            lines[lines.Length - 2] = new Line(mainDiagonal);

            // Secondary diagonal 
            var secondaryDiagonal = new Value[_values.GetLength(0)];
            for (var i = 0; i < secondaryDiagonal.Length; i++)
            {
                secondaryDiagonal[i] = _values[i, _values.GetLength(0) - i - 1];
            }
            lines[lines.Length - 1] = new Line(secondaryDiagonal);

            return lines;
        }

        public void PlaceSymbol(int row, int column, char symbol)
        {
            if (row <= 0 || column <= 0 || row > _values.GetLength(0) || column > _values.GetLength(1))
            {
                throw new ArgumentException("Invalid board position.");
            }

            _values[row - 1, column - 1].Symbol = symbol;
        }

        public void Display()
        {
            for (int i = 0; i < _values.GetLength(0); i++)
            {
                for (int j = 0; j < _values.GetLength(1); j++)
                {
                    Console.Write($"{_values[i, j].Symbol, 2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
