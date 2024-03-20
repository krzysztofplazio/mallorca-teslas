using AutoMapper;
using MallorcaTeslas.Application.Dtos.Cars;
using MallorcaTeslas.Core.Repositories.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Cars.GetCarById;

public class GetCarByIdHandler(IMapper mapper, ICarsRepository carsRepository) : IRequestHandler<GetCarByIdQuery, CarDto?>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICarsRepository _carsRepository = carsRepository;

    public async Task<CarDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carsRepository.GetCarById(request.Id, cancellationToken).ConfigureAwait(false);
        return _mapper.Map<CarDto?>(car);
    }
}
