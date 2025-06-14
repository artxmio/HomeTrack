using MediatR;

namespace HomeTrack.Application.Residents.Commands.DeleteResident;

public class DeleteResidentCommand : IRequest
{
    public Guid Id { get; set; }
}
