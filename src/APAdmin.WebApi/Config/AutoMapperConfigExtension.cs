using APAdmin.Application.ClassAttendanceModule.Queries.Profiles;

namespace APAdmin.WebApi.Config;

public static class AutoMapperConfigExtension
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(opt =>
        {
            opt.AddProfile<AttendanceProfile>();
        });
    }
}