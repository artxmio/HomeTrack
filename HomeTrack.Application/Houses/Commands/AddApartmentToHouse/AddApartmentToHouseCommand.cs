using MediatR;

namespace HomeTrack.Application.Houses.Commands.AddApartmentToHouse;

public class AddApartmentToHouseCommand : 
    IRequest
{
    public Guid ApartmentId { get; set; }
    public Guid HouseId { get; set; }
}