using Countify.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Countify.Infrastructure.Persistence;

public class CountifyDbContextFactory : IDesignTimeDbContextFactory<CountifyDbContext>
{
    public CountifyDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CountifyDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new CountifyDbContext(optionsBuilder.Options, new DesignTimeCurrentUserService());
    }
    
    private class DesignTimeCurrentUserService : ICurrentUserService
    {
        public (Guid UserId, string UserName) GetCurrentUser() => (Guid.Empty, "System");
    }
}