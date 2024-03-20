using AutoMapper;
using MallorcaTeslas.Application.Dtos.Customers;
using MallorcaTeslas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Customer>().ReverseMap();
    }
}
