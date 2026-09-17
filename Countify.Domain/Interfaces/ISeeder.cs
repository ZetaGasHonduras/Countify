namespace Countify.Domain.Interfaces;

public interface ISeeder
{
    Task SeedAsync(CancellationToken cancellationToken = default);
}