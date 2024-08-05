namespace U_242Project
{
    internal class Value
    {
        public const char Default = '*';
        public const char Cross = 'x';
        public const char Round = 'o';

        private char _symbol;

        public Value()
        {
            _symbol = Default;
        }

        public char Symbol 
        { 
            get => _symbol;
            set
            {
                if (value == Cross || value == Round)
                {
                    _symbol = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid symbol.");
                }
            }
        }
    }
}
