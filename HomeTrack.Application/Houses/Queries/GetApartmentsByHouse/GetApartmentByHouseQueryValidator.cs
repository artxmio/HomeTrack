using FluentValidation;

namespace HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;

public class GetApartmentByHouseQueryValidator
    : AbstractValidator<GetApartmentByHouseQuery>
{
    public GetApartmentByHouseQueryValidator()
    {
        RuleFor(query => query.HouseId)
            .NotEqual(Guid.Empty)
            .WithMessage("HouseId must not be an empty GUID");
    }
}