using FluentValidation;
using MallorcaTeslas.Application.Commands.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Validators.Rentals;

public class CreateRentalValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalValidator()
    {
        RuleFor(x => x.TotalPrice).NotNull().NotEmpty().PrecisionScale(14, 2, ignoreTrailingZeros: true).GreaterThanOrEqualTo(0);
        RuleFor(x => x.From).NotNull().NotEmpty().LessThan(x => x.To);
        RuleFor(x => x.To).NotNull().NotEmpty().GreaterThan(x => x.From);
        RuleFor(x => x.BorrowPlaceId).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.ReturnPlaceId).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.Customer.FullName).NotNull().NotEmpty().MaximumLength(60);
        RuleFor(x => x.Customer.DateOfBirth).NotNull().NotEmpty().LessThanOrEqualTo(DateTime.UtcNow.Date.AddYears(-18));
        RuleFor(x => x.Customer.Address).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x => x.Customer.Country).NotNull().NotEmpty().MaximumLength(25);
        RuleFor(x => x.Customer.Phone).NotNull().NotEmpty().MaximumLength(12);
        RuleFor(x => x.Customer.Email).NotNull().NotEmpty().MaximumLength(30).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        RuleFor(x => x.CarId).NotNull().NotEmpty().GreaterThan(0);
    }
}
