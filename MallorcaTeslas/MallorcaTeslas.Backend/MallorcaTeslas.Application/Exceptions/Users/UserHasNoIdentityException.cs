using System.Runtime.Serialization;

namespace MallorcaTeslas.Application.Exceptions.Users;

[Serializable]
public class UserHasNoIdentityException : UserException
{
    public UserHasNoIdentityException()
    {
    }

    public UserHasNoIdentityException(string? message) : base(message)
    {
    }

    public UserHasNoIdentityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}