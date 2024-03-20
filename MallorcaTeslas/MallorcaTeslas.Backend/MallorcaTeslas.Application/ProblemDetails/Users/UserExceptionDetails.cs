using MallorcaTeslas.Application.Constants.Users;
using MallorcaTeslas.Application.Exceptions.Users;
using Microsoft.AspNetCore.Http;

namespace MallorcaTeslas.Application.ProblemDetails.Users;

public class UserExceptionDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public UserExceptionDetails(UserException exception)
    {
        Status = StatusCodes.Status400BadRequest;
        Title = "User Problem.";
        Detail = exception.Message;
        Type = "http://api.mallorcateslas.com/users/problem";
        switch (exception.ErrorCode)
        {
            case UserExceptionErrorCodes.UserNotExist:
                Type += "/user-not-exist";
                Status = StatusCodes.Status404NotFound;
                break;
            case UserExceptionErrorCodes.BadUsernameOrPassword:
                Type += "/bad-username-or-password";
                break;
            case UserExceptionErrorCodes.UserHasNoIdentity:
                Type += "/user-has-no-identity";
                Status = StatusCodes.Status404NotFound;
                break;
            case UserExceptionErrorCodes.UsernameTaken:
                Type += "/username-taken";
                Status = StatusCodes.Status422UnprocessableEntity;
                break;
        }
    }
}