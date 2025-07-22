using FluentValidation;

namespace HomeTrack.Application.Apartments.Commands.UpdateApartment;

public class UpdateApartmentCommandValidator
    : AbstractValidator<UpdateApartmentCommand>
{
    public UpdateApartmentCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id must not be an empty GUID");

        RuleFor(command => command.Number)
            .NotNull()
            .Length(4)
            .Matches(@"^\d{4}$")
            .WithMessage("Apartment number must consist of 4 digits");

        RuleFor(command => command.Entrance)
            .GreaterThan(0)
            .NotEmpty()
            .WithMessage("Entrance must contain only digits");

        RuleFor(command => command.Area)
            .GreaterThan(0)
            .WithMessage("Area must be between 1 and 1000 m²");

        RuleFor(command => command.Floor)
            .InclusiveBetween(1, 1000)
            .WithMessage("Floor must be in the range from 1 to 1000");
    }
}
