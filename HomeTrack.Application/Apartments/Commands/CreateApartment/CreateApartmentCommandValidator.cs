using FluentValidation;

namespace HomeTrack.Application.Apartments.Commands.CreateApartment;

public class CreateApartmentCommandValidator
    : AbstractValidator<CreateApartmentCommand>
{
    public CreateApartmentCommandValidator()
    {
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

        RuleFor(command => command.HouseId)
            .NotEqual(Guid.Empty)
            .WithMessage("HouseId must not be an empty GUID");
    }
}
