using AutoMapper;
using MallorcaTeslas.Application.Constants.Cars;
using MallorcaTeslas.Application.Exceptions.Cars;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Customers;
using MallorcaTeslas.Core.Repositories.Rentals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Commands.Rentals;

public class CreateRentalHandler(IMapper mapper, IRentalsRepository rentalsRepository) : IRequestHandler<CreateRentalCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRentalsRepository _rentalsRepository = rentalsRepository;

    public async Task Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var rental = _mapper.Map<Rental>(request);
        if (request.CustomerId is not null)
        {
            rental.Customer = null!;
        }

        if ((await _rentalsRepository.GetRentalsByDates(request.From, request.To, cancellationToken).ConfigureAwait(false)).Any())
        {
            throw new CarAlreadyRentException(CarExceptionErrorCodes.CarAlreadyRent);
        }

        await _rentalsRepository.CreateRental(rental, cancellationToken).ConfigureAwait(false);
    }
}
