using FluentValidation;

namespace HomeTrack.Application.Residents.Queries.GetResidentDetails;

public class GetResidentDetailsQueryValidator
    : AbstractValidator<GetResidentDetailsQuery>
{
    public GetResidentDetailsQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentId must not be an empty GUID");
    }
}