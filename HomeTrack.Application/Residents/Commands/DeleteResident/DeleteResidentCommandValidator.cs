using FluentValidation;

namespace HomeTrack.Application.Residents.Commands.DeleteResident;

public class DeleteResidentCommandValidator
    : AbstractValidator<DeleteResidentCommand>
{
    public DeleteResidentCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentId must not be an empty GUID");
    }
}