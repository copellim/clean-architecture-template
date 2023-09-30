using System.Runtime.Serialization;

namespace Domain.Exceptions;

public abstract class DomainExceptions : Exception
{
    protected DomainExceptions() : base()
    {

    }

    protected DomainExceptions(string message) : base(message)
    {
    }

    protected DomainExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }

    public DomainExceptions(string? message, Exception? innerException) : base(message, innerException)
    {

    }
}
