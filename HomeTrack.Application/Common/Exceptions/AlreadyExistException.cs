namespace HomeTrack.Application.Exceptions;

public class AlreadyExistException(string name, string fkName, object key) :
    Exception($"Entity \"{name}\" alredy have foreign key \"{fkName}\" ({key})") {}