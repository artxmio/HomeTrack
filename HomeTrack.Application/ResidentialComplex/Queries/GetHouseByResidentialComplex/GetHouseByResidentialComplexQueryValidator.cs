using FluentValidation;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetHouseByResidentialComplex;

public class GetHouseByResidentialComplexQueryValidator
    : AbstractValidator<GetHouseByResidentialComplexQuery>
{
    public GetHouseByResidentialComplexQueryValidator()
    {
        RuleFor(query => query.ResidentialComplexId)
            .NotEqual(Guid.Empty)
            .WithMessage("ResidentialComplexId must not be an empty GUID");
    }
}