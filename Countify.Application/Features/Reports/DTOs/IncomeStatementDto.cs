namespace Countify.Application.Features.Reports.DTOs;

public class IncomeStatementLineDto
{
    public Guid AccountId { get; set; }
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}

public class IncomeStatementSectionDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public List<IncomeStatementLineDto> Lines { get; set; } = [];
}

public class IncomeStatementDto
{
    public DateTime EndDate { get; set; }
    public List<IncomeStatementSectionDto> Sections { get; set; } = [];
    public decimal TotalRevenue { get; set; }
    public decimal TotalCostOfSales { get; set; }
    public decimal GrossProfit { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal NetResult { get; set; }
}