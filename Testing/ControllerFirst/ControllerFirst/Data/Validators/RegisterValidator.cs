using ControllerFirst.DTO.Requests;
using ControllerFirst.Data.Models;

using ControllerFirst.Shared;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Interceptors;

namespace ControllerFirst.Data.Validators;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(50)
            .WithMessage("Username must not exceed 50 characters")
            .Matches(RegexPattern.Username)
            .WithMessage("Username must be at least 6 characters long and contain only letters, numbers, underscores, and hyphens");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long")
            .Matches(RegexPattern.Password)
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one number");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid");
    }


}