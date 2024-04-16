using APAdmin.Application.ClassAttendanceModule.Commands.Register;

namespace APAdmin.WebApi.Config;

public static class MediatRConfigExtension
{
    public static void ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<RegisterClassAttendanceRequest>();
            cfg.RegisterServicesFromAssemblyContaining<Program>();
        });
    }
}
