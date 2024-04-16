using APAdmin.Domain.ClassAttendanceModule;
using APAdmin.Domain.TeamModule;

namespace APAdmin.Domain.StudentModule;

public partial class Student : EntityBase<Student>
{
    protected Student()
    {
    }

    public Student(string fullName, string meetingName, Team team)
    {
        FullName = fullName;
        MeetingName = meetingName;
        Team = team;
        TeamId = team.Id;
    }

    public string FullName { get; set; }

    public string MeetingName { get; set; }

    public Team Team { get; set; }

    public Guid TeamId { get; set; }

    public List<ClassAttendance> ClassesAttendances { get; set; }

    public List<ClassAttendanceGroupedByWeek> GetAttendancesGrouped()
    {       
        ClassAttendanceGrouper grouper = new ClassAttendanceGrouper();

        return grouper.GroupByWeek(ClassesAttendances);       
    }

    public int GetAbsentCount()
    {
        return ClassesAttendances.Count(x => x.Present == false);
    }

    public int GetPresentCount()
    {
        return ClassesAttendances.Count(x => x.Present == true);
    }
}