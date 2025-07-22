using FluentValidation;

namespace HomeTrack.Application.Residents.Commands.UpdateResident;

public class UpdateResidentCommandValidator 
    : AbstractValidator<UpdateResidentCommand>
{
    public UpdateResidentCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentId must not be an empty GUID");

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