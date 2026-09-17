using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class ProjectGroup : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<Project> Projects { get; set; } = [];
}