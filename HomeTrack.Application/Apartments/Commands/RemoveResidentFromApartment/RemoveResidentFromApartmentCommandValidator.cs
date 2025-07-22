using FluentValidation;

namespace HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;

public class RemoveResidentFromApartmentCommandValidator
    : AbstractValidator<RemoveResidentFromApartmentCommand>
{
    public RemoveResidentFromApartmentCommandValidator()
    {
        RuleFor(command => command.ResidentId)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentId must not be an empty GUID");

        RuleFor(command => command.ApartmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("ApartmentId must not be an empty GUID");
    }
}
