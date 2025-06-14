using MediatR;
using System.Net;

namespace HomeTrack.Application.Residents.Commands.CreateResident;

public class CreateResidentCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
}
