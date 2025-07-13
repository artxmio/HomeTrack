using MediatR;

namespace HomeTrack.Application.Houses.Commands.RemoveApartmentFromHouse;

public class RemoveApartmentFromHouseCommand : 
    IRequest
{
    public Guid ApartmentId { get; set; }
    public Guid HouseId { get; set; }
}