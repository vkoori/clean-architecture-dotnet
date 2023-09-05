namespace Application.Exceptions.RuntimeExceptions;

using Application.Exceptions;

public class InterfaceBindingException : RuntimeException
{
    public InterfaceBindingException() : base(message: "Interface is not binding to destination class.")
    { }
}
