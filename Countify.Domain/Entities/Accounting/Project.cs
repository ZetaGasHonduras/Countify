using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Project : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? GroupId { get; set; }
    public ProjectGroup? Group { get; set; }
}