using APAdmin.Infra.Database.ClassAttendanceModule;
using APAdmin.Infra.Database.TeamModule;
using APAdmin.Infra.Database.StudentModule;

namespace APAdmin.Infra.Database;

public class APAdminDbContext : DbContext, IUnitOfWork
{
    public APAdminDbContext(DbContextOptions options) : base(options)
    {
    }

    public bool CommitChanges()
    {
        return SaveChanges() > 0;
    }

    public bool Roolback()
    {
        var registersWithChanges = ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged)
            .ToList();

        foreach (var registers in registersWithChanges)
        {
            switch (registers.State)
            {
                case EntityState.Added:
                    registers.State = EntityState.Detached;
                    break;

                case EntityState.Deleted:
                    registers.State = EntityState.Unchanged;
                    break;

                case EntityState.Modified:
                    registers.State = EntityState.Unchanged;
                    registers.CurrentValues.SetValues(registers.OriginalValues);
                    break;

                default:
                    break;
            }
        }

        return true;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
        {
            x.AddSerilog(Log.Logger);
        });

        optionsBuilder.UseLoggerFactory(loggerFactory);

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClassAttendanceMapperOrm());
        modelBuilder.ApplyConfiguration(new TeamMapperOrm());
        modelBuilder.ApplyConfiguration(new StudentMapperOrm());

        base.OnModelCreating(modelBuilder);
    }
}