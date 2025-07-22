using FluentValidation;

namespace HomeTrack.Application.Apartments.Commands.AddResidentToApartment;

public class AddResidentToAppartmentCommandValidator 
    : AbstractValidator<AddResidentToApartmentCommand>
{
    public AddResidentToAppartmentCommandValidator()
    {
        RuleFor(command => command.ApartmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("ApartmentId must not be an empty GUID");

        RuleFor(command => command.ResidentId)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentId must not be an empty GUID");
    }
}
