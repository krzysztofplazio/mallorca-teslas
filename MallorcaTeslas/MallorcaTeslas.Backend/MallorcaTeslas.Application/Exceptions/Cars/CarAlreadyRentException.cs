using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Exceptions.Cars;

public class CarAlreadyRentException : CarException
{
    public CarAlreadyRentException()
    {
    }

    public CarAlreadyRentException(string? message) : base(message)
    {
    }

    public CarAlreadyRentException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
