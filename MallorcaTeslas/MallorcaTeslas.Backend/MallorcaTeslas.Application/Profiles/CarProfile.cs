using AutoMapper;
using MallorcaTeslas.Application.Dtos.Cars;
using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<PagedItems<Car>, PagedItems<CarDto>>();
    }
}
