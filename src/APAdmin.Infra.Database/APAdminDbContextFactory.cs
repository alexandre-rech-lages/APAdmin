using Microsoft.EntityFrameworkCore.Design;

namespace APAdmin.Infra.Database;

public class APAdminDbContextFactory : IDesignTimeDbContextFactory<APAdminDbContext>
{
    public APAdminDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<APAdminDbContext>();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("MySql");

        builder
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .EnableDetailedErrors(true);

        return new APAdminDbContext(builder.Options);
    }
}
