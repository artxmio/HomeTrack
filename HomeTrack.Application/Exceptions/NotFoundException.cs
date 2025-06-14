using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HomeTrack.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) not found.") {}
}
