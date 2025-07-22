using FluentValidation;

namespace HomeTrack.Application.Houses.Queries.GetHouseDetails;

public class GetHouseDetailsQueryValidator
    : AbstractValidator<GetHouseDetailsQuery>
{
    public GetHouseDetailsQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("HouseId must not be an empty GUID");
    }
}