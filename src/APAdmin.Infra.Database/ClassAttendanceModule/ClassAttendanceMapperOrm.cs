
using APAdmin.Domain.ClassAttendanceModule;

namespace APAdmin.Infra.Database.ClassAttendanceModule;

public class ClassAttendanceMapperOrm : IEntityTypeConfiguration<ClassAttendance>
{
    public void Configure(EntityTypeBuilder<ClassAttendance> modelBuilder)
    {
        modelBuilder.ToTable("TBClassAttendance");

        modelBuilder.Property(x => x.Id).ValueGeneratedNever();

        modelBuilder.Property(x => x.Date);

        modelBuilder.Property(x => x.Week);

        modelBuilder.Property(x => x.Month);

        modelBuilder.Property(x => x.Present);

        modelBuilder.HasOne(a => a.Team)
           .WithMany()
           .HasForeignKey(a => a.TeamId)
           .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.HasOne(a => a.Student)
            .WithMany(s => s.ClassesAttendances)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
