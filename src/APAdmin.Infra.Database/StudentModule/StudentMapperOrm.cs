using APAdmin.Domain.StudentModule;

namespace APAdmin.Infra.Database.StudentModule;

public class StudentMapperOrm : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> modelBuilder)
    {
        modelBuilder.ToTable("TBStudent");

        modelBuilder.Property(x => x.Id).ValueGeneratedNever();

        modelBuilder.HasOne(x => x.Team);

        modelBuilder.HasMany(x => x.ClassesAttendances)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);            
    }
}