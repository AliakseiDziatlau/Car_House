using Back_end.Application.DTOs;
using FluentValidation;

namespace Back_end.Presentation.Validators;

public class CreateCarValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarValidator()
    {
        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand is required");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required")
            .MaximumLength(100).WithMessage("Model cannot exceed 100 characters");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage($"Year must be between 1900 and {DateTime.Now.Year + 1}");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0).WithMessage("Mileage cannot be negative");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("Image URL cannot exceed 500 characters");
    }
}

public class UpdateCarValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarValidator()
    {
        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand is required");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required")
            .MaximumLength(100).WithMessage("Model cannot exceed 100 characters");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage($"Year must be between 1900 and {DateTime.Now.Year + 1}");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0).WithMessage("Mileage cannot be negative");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("Image URL cannot exceed 500 characters");
    }
}
