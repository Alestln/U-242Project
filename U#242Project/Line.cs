namespace U_242Project
{
    internal class Line
    {
        private readonly Value[] _values;

        public Line(Value[] values)
        {
            _values = values;
        }

        public char? IsWinningLine()
        {
            if (_values.Length == 0 || _values[0].Symbol == Value.Default)
            {
                return null;
            }

            var firstSymbol = _values[0].Symbol;

            foreach (var item in _values)
            {
                if (item.Symbol != firstSymbol)
                {
                    return null;
                }
            }

            return firstSymbol;
        }
    }
}
