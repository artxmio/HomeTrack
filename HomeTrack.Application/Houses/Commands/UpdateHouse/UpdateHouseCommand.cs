using MediatR;

namespace HomeTrack.Application.Houses.Commands.UpdateHouse;

public class UpdateHouseCommand : IRequest
{
    public Guid Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int NumberOfFloors { get; set; }
    public int NumberOfEntrances { get; set; }
}