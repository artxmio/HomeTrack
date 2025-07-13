using MediatR;

namespace HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;

public class GetApartmentByHouseQuery : 
    IRequest<ApartmentByHouseVm>
{
    public Guid HouseId { get; set; }
}