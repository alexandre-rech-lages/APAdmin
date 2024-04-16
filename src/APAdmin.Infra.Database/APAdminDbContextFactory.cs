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

        var connectionString = config.GetConnectionString("SqlServer");

        builder.UseSqlServer(connectionString);

        return new APAdminDbContext(builder.Options);
    }
}
