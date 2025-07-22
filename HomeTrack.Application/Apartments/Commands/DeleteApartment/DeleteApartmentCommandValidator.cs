using FluentValidation;

namespace HomeTrack.Application.Apartments.Commands.DeleteApartment;

public class DeleteApartmentCommandValidator
    : AbstractValidator<DeleteApartmentCommand>
{
    public DeleteApartmentCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ApartmentId must not be an empty GUID");
    }
}
