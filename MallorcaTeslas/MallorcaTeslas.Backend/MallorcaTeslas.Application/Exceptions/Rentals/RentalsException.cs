using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Exceptions.Rentals;

[Serializable]
public class RentalsException : Exception
{
    public string? ErrorCode { get; set; }

    public RentalsException()
    {
    }

    public RentalsException(string? message) : base(message)
    {
        ErrorCode = message;
    }

    public RentalsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
