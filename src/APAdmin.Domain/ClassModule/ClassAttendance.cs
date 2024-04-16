using APAdmin.Domain.TeamModule;
using APAdmin.Domain.StudentModule;
using System.Globalization;

namespace APAdmin.Domain.ClassAttendanceModule;

public class ClassAttendance : EntityBase<ClassAttendance>
{
    private DateTime date;

    protected ClassAttendance()
    {
    }

    public ClassAttendance(Team team, Student student, DateTime date, bool present)
    {
        Team = team;
        Student = student;
        Date = date;
        Present = present;
    }

    public Team Team { get; set; }

    public Guid TeamId { get; set; }

    public Student Student { get; set; }

    public Guid StudentId { get; set; }
    
    public DateTime Date
    {
        get { return date; }
        set
        {
            date = value;

            SetWeek();

            SetMonth();
        }
    }   

    public string Week { get; set; }

    public string Month { get; set; }

    public bool Present { get; set; }

    private void SetMonth()
    {
        CultureInfo cultura = new CultureInfo("pt-BR");

        string nomeMes = date.ToString("MMMM", cultura);

        Month = cultura.TextInfo.ToTitleCase(nomeMes);
    }

    private void SetWeek()
    {
        DateTime startOfYear = new DateTime(date.Year, 1, 1);

        const int oneDay = 24, oneHour = 60, oneMinute = 60, oneSecond = 1000;

        double oneDayInMilliseconds = oneDay * oneHour * oneMinute * oneSecond;  //86400000

        double diff = (date - startOfYear).TotalMilliseconds / oneDayInMilliseconds;

        int weekNumber = (int)Math.Ceiling((diff + (int)startOfYear.DayOfWeek) / 7);

        int firstWeeks = 10;

        string weekString = (weekNumber - firstWeeks).ToString().PadLeft(2, '0');

        Week = $"Semana {weekString}";
    }

}