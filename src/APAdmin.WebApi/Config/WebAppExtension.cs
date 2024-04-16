using APAdmin.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace APAdmin.WebApi.Config;

public static class WebAppExtension
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<APAdminDbContext>();
            dataContext.Database.Migrate();
        }
    }
}