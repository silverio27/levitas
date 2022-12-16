using System.Runtime.Serialization;

namespace domain.Troca.Excepitions;
public class TrocaExceptions : Exception
{
    public TrocaExceptions()
    {
    }

    public TrocaExceptions(string? message) : base(message)
    {
    }

    public TrocaExceptions(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected TrocaExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
