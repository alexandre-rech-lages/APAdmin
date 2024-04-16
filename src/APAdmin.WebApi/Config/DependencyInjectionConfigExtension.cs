using APAdmin.Domain;
using APAdmin.Domain.ClassAttendanceModule;
using APAdmin.Domain.TeamModule;
using APAdmin.Domain.StudentModule;
using APAdmin.Infra.Database;
using APAdmin.Infra.Database.ClassAttendanceModule;
using APAdmin.Infra.Database.TeamModule;
using APAdmin.Infra.Database.StudentModule;
using Microsoft.EntityFrameworkCore;

namespace APAdmin.WebApi.Config;

public static class DependencyInjectionConfigExtension
{
    public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySql");

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException(nameof(connectionString));        

        services.AddDbContext<IUnitOfWork, APAdminDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .EnableDetailedErrors(true));

        services.AddTransient<ITeamRepository, TeamRepositoryOrm>();
        services.AddTransient<IStudentRepository, StudentRepositoryOrm>();
        services.AddTransient<IClassAttendanceRepository, ClassAttendanceRepositoryOrm>();

    }


}
