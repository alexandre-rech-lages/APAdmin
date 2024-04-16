using APAdmin.Domain.StudentModule;

namespace APAdmin.Domain.TeamModule;

public class Team : EntityBase<Team>
{    
    protected Team()
    {
    }

    public Team(int year, string name)
    {
        this.Year = year;
        this.Name = name;
    }

    public string Name { get; set; }

    public List<Student> Students { get; set; }

    public int Year { get; set; }


}