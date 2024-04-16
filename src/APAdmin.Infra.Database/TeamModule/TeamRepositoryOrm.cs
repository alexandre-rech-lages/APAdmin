using APAdmin.Domain.TeamModule;

namespace APAdmin.Infra.Database.TeamModule;

public class TeamRepositoryOrm : RepositoryBase<Team>, ITeamRepository
{
    public TeamRepositoryOrm(IUnitOfWork contextData) : base(contextData)
    {
    }

    public Team GetByYear(int year, bool includeStudents)
    {
        if (includeStudents) 
            return this.registers
                .Include(x => x.Students)
                .FirstOrDefault(x => x.Year == year);

        return this.registers
                .FirstOrDefault(x => x.Year == year);
    }
}
