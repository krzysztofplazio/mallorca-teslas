using AutoMapper;
using MallorcaTeslas.Application.Commands.Rentals;
using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Dtos.Rentals;
using MallorcaTeslas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Profiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<CreateRentalCommand, Rental>();
        CreateMap<Rental, GetRentalsReponse>()
            .ForMember(dest => dest.ReturnPlace,
                       opt => opt.MapFrom(src => src.ReturnPlace.Location))
            .ForMember(dest => dest.BorrowPlace,
                       opt => opt.MapFrom(src => src.BorrowPlace.Location))
            .ForMember(dest => dest.Car,
                       opt => opt.MapFrom(src => src.Car.Model));
        CreateMap<PagedItems<Rental>, PagedItems<GetRentalsReponse>>();
    }
}
