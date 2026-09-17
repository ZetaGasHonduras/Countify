namespace Countify.Application.Features.DocumentTypes.DTOs;

public class DocumentTypeDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool IsDefault { get; set; }
}