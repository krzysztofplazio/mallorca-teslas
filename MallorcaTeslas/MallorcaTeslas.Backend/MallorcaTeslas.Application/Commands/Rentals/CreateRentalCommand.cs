using MallorcaTeslas.Application.Dtos.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Commands.Rentals;

public class CreateRentalCommand(decimal totalPrice,
                                 DateTime from,
                                 DateTime to,
                                 int borrowPlaceId,
                                 int returnPlaceId,
                                 CustomerDto customer,
                                 int? customerId,
                                 int carId) : IRequest
{
    public decimal TotalPrice { get; } = totalPrice;
    public DateTime From { get; } = from;
    public DateTime To { get; } = to;
    public int BorrowPlaceId { get; } = borrowPlaceId;
    public int ReturnPlaceId { get; } = returnPlaceId;
    public CustomerDto Customer { get; } = customer;
    public int? CustomerId { get; } = customerId;
    public int CarId { get; } = carId;
}
