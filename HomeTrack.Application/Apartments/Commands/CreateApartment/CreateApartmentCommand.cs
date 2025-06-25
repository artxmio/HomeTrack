using MediatR;

namespace HomeTrack.Application.Apartments.Commands.CreateApartment;

public class CreateApartmentCommand : IRequest<Guid>
{
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }

    public Guid HouseId { get; set; }
}
