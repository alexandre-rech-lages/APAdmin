using APAdmin.Domain.ClassAttendanceModule;

namespace APAdmin.Domain.StudentModule;

public class ClassAttendanceGroupedByWeek
{    
    public ClassAttendanceGroupedByWeek(string week, List<ClassAttendance> classAttendances)
    {
        Week = week;
        ClassAttendances = classAttendances;
    }

    private List<ClassAttendance> ClassAttendances { get; set; }

    public string Week { get; set; }
    

    public int GetAbsentCount()
    {
        return ClassAttendances.Count(x => x.Present == false);
    }

    public int GetPresentCount()
    {
        return ClassAttendances.Count(x => x.Present == true);
    }
}
