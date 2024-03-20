using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Exceptions.Cars;

[Serializable]
public class CarException : Exception
{
    public string? ErrorCode { get; set; }

    public CarException()
    {
    }

    public CarException(string? message) : base(message)
    {
        ErrorCode = message;
    }

    public CarException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
