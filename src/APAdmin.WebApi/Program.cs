namespace APAdmin.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        //testetest
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ConfigureSerilog();

        builder.Services.AddControllers();

        builder.Services.ConfigureAutoMapper();

        builder.Services.ConfigureDependencyInjection(builder.Configuration);

        builder.Services.ConfigureMediatR();

        builder.Services.ConfigureSwagger();

        var app = builder.Build();

        app.MigrateDatabase();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI();

        if (app.Environment.IsDevelopment())
        {           
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}