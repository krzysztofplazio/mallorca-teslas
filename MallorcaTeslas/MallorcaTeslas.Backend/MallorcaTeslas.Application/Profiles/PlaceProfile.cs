using AutoMapper;
using MallorcaTeslas.Core.Dtos.Places;
using MallorcaTeslas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Profiles;

public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<Place, PlaceDto>();
    }
}
