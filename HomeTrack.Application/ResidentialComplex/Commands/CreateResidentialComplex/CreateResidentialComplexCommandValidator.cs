using FluentValidation;

namespace HomeTrack.Application.ResidentialComplex.Commands.CreateResidentialComplex;

public class CreateResidentialComplexCommandValidator
    : AbstractValidator<CreateResidentialComplexCommand>
{
    public CreateResidentialComplexCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .Length(2, 255)
            .WithMessage("The name must be between 2 and 255 characters");
    }
}
