using System.Runtime.Serialization;

namespace MallorcaTeslas.Application.Exceptions.Users;

[Serializable]
public class BadUsernameOrPasswordException : UserException
{
    public BadUsernameOrPasswordException()
    {
    }

    public BadUsernameOrPasswordException(string? message) : base(message)
    {
    }

    public BadUsernameOrPasswordException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}