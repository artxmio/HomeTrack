using FluentValidation;

namespace HomeTrack.Application.Houses.Commands.DeleteHouse;

public class DeleteHouseCommandValidator 
    : AbstractValidator<DeleteHouseCommand>
{
    public DeleteHouseCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("HouseId must not be an empty GUID");
    }
}
