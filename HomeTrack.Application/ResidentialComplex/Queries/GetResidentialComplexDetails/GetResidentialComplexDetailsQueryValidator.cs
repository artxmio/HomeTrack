using FluentValidation;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexDetails;

public class GetResidentialComplexDetailsQueryValidator
    : AbstractValidator<GetResidentialComplexDetailsQuery>
{
    public GetResidentialComplexDetailsQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentialComplexId must not be an empty GUID");
    }
}
