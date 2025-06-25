using MediatR;

namespace HomeTrack.Application.Houses.Commands.CreateHouse;

public class CreateHouseCommand : IRequest<Guid>
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int NumberOfFloors { get; set; }
    public int NumberOfEntrances { get; set; }

    public Guid ResidentialComplexId { get; set; }
}
