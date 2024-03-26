namespace Adalio.Exceptions
{
    public class NotPhoneException: Exception
    {
        public NotPhoneException(): base("Phone number is missing.") { }
        public NotPhoneException(string message) : base(message) { }  
    }
}
