using FluentValidation;

namespace HomeTrack.Application.Apartments.Queries.GetResidentsByApartment;

public class GetResidentsByApartmentQueryValidator
    : AbstractValidator<GetResidentsByApartmentQuery>
{
    public GetResidentsByApartmentQueryValidator()
    {
        RuleFor(query => query.ApartmentId)
            .NotEqual(Guid.Empty)
            .WithMessage("ApartmentId must not be an empty GUID");
    }
}
