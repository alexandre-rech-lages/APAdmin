using APAdmin.Domain.ClassAttendanceModule;

namespace APAdmin.Domain.StudentModule;

public class ClassAttendanceGrouper
{
    public List<ClassAttendanceGroupedByWeek> GroupByWeek(List<ClassAttendance> attendances)
    {
        var attendancesMap = new Dictionary<string, List<ClassAttendance>>();

        foreach (var item in attendances)
        {
            List<ClassAttendance> list;

            if (attendancesMap.TryGetValue(item.Week, out list))
                list.Add(item);
            else
                attendancesMap[item.Week] = new List<ClassAttendance> { item };
        }

        var attendancesGrouped = new List<ClassAttendanceGroupedByWeek>();

        foreach (var item in attendancesMap)
        {
            attendancesGrouped.Add(new ClassAttendanceGroupedByWeek(item.Key, item.Value));
        }
            
        return attendancesGrouped;
    }
}
