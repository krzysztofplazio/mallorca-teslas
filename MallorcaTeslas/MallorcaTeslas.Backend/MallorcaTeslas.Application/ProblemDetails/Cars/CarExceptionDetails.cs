using MallorcaTeslas.Application.Constants.Cars;
using MallorcaTeslas.Application.Constants.Users;
using MallorcaTeslas.Application.Exceptions.Cars;
using MallorcaTeslas.Application.Exceptions.Users;
using Microsoft.AspNetCore.Http;

namespace MallorcaTeslas.Application.ProblemDetails.Users;

public class CarExceptionDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public CarExceptionDetails(CarException exception)
    {
        Status = StatusCodes.Status400BadRequest;
        Title = "Car Problem.";
        Detail = exception.Message;
        Type = "http://api.mallorcateslas.com/users/problem";
        switch (exception.ErrorCode)
        {
            case CarExceptionErrorCodes.CarAlreadyRent:
                Title = "Car rental problem";
                Type += "/car-already-rent";
                Status = StatusCodes.Status409Conflict;
                break;
        }
    }
}