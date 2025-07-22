using FluentValidation;

namespace HomeTrack.Application.ResidentialComplex.Commands.DeleteResidentialComplex;

public class DeleteResidentialComplexCommandValidator
    : AbstractValidator<DeleteResidentialComplexCommand>
{
    public DeleteResidentialComplexCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentialComplexId must not be an empty GUID");
    }
}
