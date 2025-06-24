using MediatR;

namespace HomeTrack.Application.Houses.Queries.GetHouseDetails;

public class GetHouseDetailsQuery : IRequest<HouseDetailsVm>
{
    public Guid Id { get; set; }
}