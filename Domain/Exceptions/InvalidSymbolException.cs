namespace Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public InvalidSymbolException(string symbol)
            : base($"Symbol \"{symbol}\" is not valid.")
        {
        }
    }
}
