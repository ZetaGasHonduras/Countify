namespace Countify.Application.Features.Historie.DTOs;

public class HistoryDto
{
    public string Entity { get; set; } = string.Empty;
    public string Property { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string OldValue { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty;
}