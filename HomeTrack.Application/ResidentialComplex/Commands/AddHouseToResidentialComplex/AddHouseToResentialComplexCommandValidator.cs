using FluentValidation;

namespace HomeTrack.Application.ResidentialComplex.Commands.AddHouseToResidentialComplex;

public class AddHouseToResentialComplexCommandValidator 
    : AbstractValidator<AddHouseToResidentialComplexCommand>
{
    public AddHouseToResentialComplexCommandValidator()
    {
        RuleFor(command => command.ResidentialComplexId)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentialComplexId must not be an empty GUID");

        RuleFor(command => command.HouseId)
            .NotEqual(Guid.Empty)
            .WithMessage("HouseId must not be an empty GUID");
    }
}
