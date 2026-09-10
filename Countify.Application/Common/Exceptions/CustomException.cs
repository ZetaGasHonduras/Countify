namespace Countify.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}

public class ValidationException() : Exception("One or more validation failures have occurred.")
{
    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

    public ValidationException(IDictionary<string, string[]> errors) : this()
    {
        Errors = errors;
    }
}

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base("Access denied.")
    {
    }

    public ForbiddenAccessException(string message) : base(message)
    {
    }
}

public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base("Unauthorized.")
    {
    }

    public UnauthorizedException(string message) : base(message)
    {
    }
}