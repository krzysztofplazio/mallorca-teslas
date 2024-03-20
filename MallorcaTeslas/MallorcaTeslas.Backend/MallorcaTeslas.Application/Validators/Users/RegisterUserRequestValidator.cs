using FluentValidation;
using MallorcaTeslas.Application.Dtos.Users;

namespace MallorcaTeslas.Application.Validators.Users;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty()
           .MaximumLength(15)
           .MinimumLength(3);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(21);
    }
}
