using APAdmin.Domain.TeamModule;

namespace APAdmin.Infra.Database.TeamModule;

public class TeamMapperOrm : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> modelBuilder)
    {
        modelBuilder.ToTable("TBTeam");

        modelBuilder.Property(x => x.Id).ValueGeneratedNever();

        modelBuilder.Property(x => x.Name);

        modelBuilder.Property(x => x.Year);

        modelBuilder
            .HasMany(x => x.Students)
            .WithOne(x => x.Team)
            .HasForeignKey(x => x.TeamId);
    }
}