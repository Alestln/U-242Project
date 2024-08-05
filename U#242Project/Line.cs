namespace U_242Project
{
    internal class Line
    {
        private Value[] _values;

        public Line(Value[] values)
        {
            _values = values;
        }

        public bool IsFilled()
        {
            foreach (var value in _values)
            {
                if (value.Symbol == '*')
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsWinningLine(char symbol)
        {
            foreach (var value in _values)
            {
                if (value.Symbol != symbol)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
