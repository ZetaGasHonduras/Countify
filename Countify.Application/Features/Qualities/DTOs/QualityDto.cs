namespace Countify.Application.Features.Qualities.DTOs;

public class QualityDto
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
}