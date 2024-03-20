using AutoMapper;
using MallorcaTeslas.Application.Dtos.Cars;
using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Repositories.Cars;
using MediatR;

namespace MallorcaTeslas.Application.Queries.Cars.GetCarsByDates;

public class GetCarsByDatesHandler(ICarsRepository offersRepository, IMapper mapper) : IRequestHandler<GetCarsByDatesQuery, PagedItems<CarDto>>
{
    private readonly ICarsRepository _offersRepository = offersRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PagedItems<CarDto>> Handle(GetCarsByDatesQuery request, CancellationToken cancellationToken)
    {
        var cars = await _offersRepository.GetCarsByDates(DateTime.SpecifyKind(request.From, DateTimeKind.Utc),
                                                                   DateTime.SpecifyKind(request.To, DateTimeKind.Utc),
                                                                   request.PageNumber,
                                                                   request.PageSize,
                                                                   cancellationToken).ConfigureAwait(false);
        return _mapper.Map<PagedItems<CarDto>>(cars);
    }
}
