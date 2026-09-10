namespace Countify.Application.Wrappers;

public class Response<T>
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public string? Error { get; private set; }
    public string? Message { get; set; }
    public int StatusCode { get; private set; }

    private Response(bool isSuccess, T? data, string? error, string? message, int statusCode)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
        Message = message;
        StatusCode = statusCode;
    }

    public Response(string? message)
    {
        Message = message;
    }

    public static Response<T> Success(T data, string? message, int statusCode = 200) =>
        new(true, data, null, message, statusCode);

    public static Response<T> Success(T data, int statusCode = 200) =>
        new(true, data, null, null, statusCode);

    public static Response<T> Failure(string error, int statusCode = 400) =>
        new(false, default, error, null, statusCode);

    public static Response<T> NotFound(string error = "Recurso no encontrado.") =>
        new(false, default, error, null, 404);

    public static Response<T> Unauthorized(string error = "No autorizado.") =>
        new(false, default, error, null, 401);

    public static Response<T> Forbidden(string error = "Acceso denegado.") =>
        new(false, default, error, null, 403);
}

public class PaginatedResponse<T>(T data, int pageNumber, int pageSize, int totalCount)
{
    public T Data { get; set; } = data;
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalCount { get; set; } = totalCount;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => PageNumber > 0;
    public bool HasNextPage => PageNumber < TotalPages - 1;
}