using FluentValidation;

namespace HomeTrack.Application.ResidentialComplex.Commands.UpdateResidentialComplex;

public class UpdateResidentialComplexCommandValidator
    : AbstractValidator<UpdateResidentialComplexCommand>
{
    public UpdateResidentialComplexCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentialComplexId must not be an empty GUID");

        RuleFor(command => command.Name)
            .NotEmpty()
            .Length(2, 255)
            .WithMessage("The name must be between 2 and 255 characters");
    }
}
