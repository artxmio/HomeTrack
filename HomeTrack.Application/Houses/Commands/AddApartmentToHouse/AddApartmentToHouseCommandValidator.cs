using FluentValidation;

namespace HomeTrack.Application.Houses.Commands.AddApartmentToHouse;

public class AddApartmentToHouseCommandValidator
    : AbstractValidator<AddApartmentToHouseCommand>
{
    public AddApartmentToHouseCommandValidator()
    {
        RuleFor(command => command.ApartmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("ApartmentId must not be an empty GUID");    

        RuleFor(command => command.HouseId)
            .NotEqual(Guid.Empty)
            .WithMessage("HouseId must not be an empty GUID");
    }
}