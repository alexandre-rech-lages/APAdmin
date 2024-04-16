namespace APAdmin.Application.ClassAttendanceModule.Commands.Register;

public class ParticipantDTO
{
    public string MeetingName { get; internal set; }
    public DateTime EntryDate { get; internal set; }
    public TimeSpan TimeInClass { get; internal set; }    
}

