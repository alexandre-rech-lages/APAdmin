namespace APAdmin.Domain.TeamModule;

public interface ITeamRepository : IRepository<Team>
{
    Team GetByYear(int year, bool includeStudents);
}
