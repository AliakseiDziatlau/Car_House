using Back_end.Application.DTOs;
using FluentValidation;

namespace Back_end.Presentation.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("Car is required");

        RuleFor(x => x.Notes)
            .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters");
    }
}

public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusDto>
{
    public UpdateOrderStatusValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required")
            .Must(s => new[] { "Pending", "Approved", "Completed", "Cancelled" }.Contains(s))
            .WithMessage("Status must be one of: Pending, Approved, Completed, Cancelled");
    }
}
