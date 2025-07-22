using FluentValidation;

namespace HomeTrack.Application.Apartments.Queries.GetApartmentDetails;

public class GetApartmentDetailsQueryValidator
    : AbstractValidator<GetApartmentDetailsQuery>
{
    public GetApartmentDetailsQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id must not be an empty GUID");
    }
}
