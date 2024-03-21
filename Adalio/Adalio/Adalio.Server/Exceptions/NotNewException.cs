namespace Adalio.Exceptions
{
    public class NotNewException : UserException
    {
        public NotNewException() : base("This order doesn't have status \"new\"") { }
        public NotNewException(string message)
            : base(message)
        {
            
        }
    }
}
