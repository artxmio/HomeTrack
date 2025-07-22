namespace HomeTrack.Application.Exceptions;

public class NotFoundException(string name, object key) :
    Exception($"Entity \"{name}\" ({key}) not found.") {}