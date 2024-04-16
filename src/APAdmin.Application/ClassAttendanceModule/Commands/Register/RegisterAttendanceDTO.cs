namespace APAdmin.Application.ClassAttendanceModule.Commands.Register;

public class RegisterClassAttendanceDTO
{
    public List<ParticipantDTO> Participants { get; set; }

    public HeaderDTO Header { get; set; }

    public DateTime Date { get { return Header.StartTime.Date; } }
}

