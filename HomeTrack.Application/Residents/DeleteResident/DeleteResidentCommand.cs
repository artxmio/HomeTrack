using MediatR;

namespace HomeTrack.Application.Residents.DeleteResident;

public class DeleteResidentCommand : IRequest
{
    public Guid Id { get; set; }
}
