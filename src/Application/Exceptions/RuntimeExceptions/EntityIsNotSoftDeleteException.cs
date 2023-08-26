namespace Application.Exceptions.RuntimeExceptions;

using Application.Exceptions;

public class EntityIsNotSoftDeleteException : RuntimeException
{
    public EntityIsNotSoftDeleteException() : base(message: "Entity must be soft delete!")
    { }
}
