namespace Coren.OnlinePortal.Application.Exceptions.CustomError
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
