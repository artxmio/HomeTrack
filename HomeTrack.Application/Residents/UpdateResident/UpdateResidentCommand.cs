using MediatR;

namespace HomeTrack.Application.Residents.UpdateResident;

public class UpdateResidentCommand : IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
}
