using MallorcaTeslas.Application.Dtos.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Cars.GetCarById;

public class GetCarByIdQuery(int id) : IRequest<CarDto?>
{
    public int Id { get; } = id;
}
