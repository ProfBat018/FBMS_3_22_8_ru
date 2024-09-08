
using AuthData.DTO;
using FluentValidation;

namespace UserService.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterDTO>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .Matches(RegexPatterns.usernamePattern)
            .When(x => x.Username != null);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Valid Email is required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Matches(RegexPatterns.passwordPattern)
            .NotEqual(x => x.Username)
            .When(x => x.Password != null);

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm Password is required")
            .Equal(x => x.Password)
            .WithMessage("Password and Confirm Password must match");
    }
}
