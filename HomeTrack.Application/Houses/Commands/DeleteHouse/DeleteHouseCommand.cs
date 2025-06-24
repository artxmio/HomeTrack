using MediatR;

namespace HomeTrack.Application.Houses.Commands.DeleteHouse;

public class DeleteHouseCommand : IRequest
{
    public Guid Id { get; set; }
}