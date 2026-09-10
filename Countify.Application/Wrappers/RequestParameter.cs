namespace Countify.Application.Wrappers;

public class RequestParameter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Parameter { get; set; }
    public string? Order { get; set; }
    public string? Column { get; set; }
    public bool All { get; set; }

    public RequestParameter()
    {
        PageNumber = 0;
        PageSize = 10;
    }

    public RequestParameter(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber < 0 ? 0 : pageNumber;
        PageSize = pageSize > 10 ? 10 : pageSize;
    }
}