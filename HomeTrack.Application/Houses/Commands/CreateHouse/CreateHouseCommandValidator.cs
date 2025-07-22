using FluentValidation;

namespace HomeTrack.Application.Houses.Commands.CreateHouse;

public class CreateHouseCommandValidator
    : AbstractValidator<CreateHouseCommand>
{
    public CreateHouseCommandValidator()
    {
        RuleFor(command => command.Street)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Street name must not be empty and must be no more than 100 characters");

        RuleFor(command => command.City)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("City name must not be empty and must be no more than 100 characters");

        RuleFor(command => command.Number)
            .NotEmpty()
            .MaximumLength(255)
            .Matches(@"^\d+[A-Za-z]?$")
            .WithMessage("House number must be valid, e.g. 12 or 12A");

        RuleFor(command => command.NumberOfFloors)
            .InclusiveBetween(1, 100)
            .WithMessage("Number of floors must be between 1 and 100");

        RuleFor(command => command.NumberOfEntrances)
            .InclusiveBetween(1, 50)
            .WithMessage("Number of entrances must be between 1 and 50");

        RuleFor(command => command.ResidentialComplexId)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentialComplexId must not be an empty GUID");
    }
}