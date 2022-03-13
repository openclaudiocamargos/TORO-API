namespace Domain.Exceptions
{
    public class InvalidUserPositionException : Exception
    {
        public InvalidUserPositionException()
            : base("User position is not valid.")
        {
        }
    }
}
