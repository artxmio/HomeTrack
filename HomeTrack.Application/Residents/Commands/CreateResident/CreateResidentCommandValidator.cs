using FluentValidation;

namespace HomeTrack.Application.Residents.Commands.CreateResident;

public class CreateResidentCommandValidator
    : AbstractValidator<CreateResidentCommand>
{
    public CreateResidentCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(250)
            .Matches(@"^[\p{L}\s'-]+$")
            .WithMessage("Name must not be empty and must contain only letters, spaces, apostrophes, or hyphens");

        RuleFor(command => command.Surname)
            .NotEmpty()
            .MaximumLength(250)
            .Matches(@"^[\p{L}\s'-]+$")
            .WithMessage("Surname must not be empty and must contain only letters, spaces, apostrophes, or hyphens");
    }
}