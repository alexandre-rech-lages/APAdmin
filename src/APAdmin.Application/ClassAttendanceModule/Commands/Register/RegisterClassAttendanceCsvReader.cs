using System.Text;

namespace APAdmin.Application.ClassAttendanceModule.Commands.Register;

public class RegisterClassAttendanceCsvReader
{
    public static RegisterClassAttendanceDTO ConvertFile(byte[] file)
    {
        var data = Encoding.UTF8.GetString(file).Replace("\"", "");

        var registerClassAttendance = new RegisterClassAttendanceDTO();

        registerClassAttendance.Header = ConvertHeader(data);

        registerClassAttendance.Participants = ConvertParticipants(data);

        return registerClassAttendance;
    }

    private static List<ParticipantDTO> ConvertParticipants(string data)
    {
        var lines = data.Split('\n');

        List<ParticipantDTO> participants = new List<ParticipantDTO>();

        foreach (var line in lines)
        {
            if (IsHeader(line))
                continue;

            if (string.IsNullOrEmpty(line) == false)
            {
                ParticipantDTO participant = ConvertParticipant(line);

                participants.Add(participant);
            }
        }

        return participants;
    }

    private static ParticipantDTO ConvertParticipant(string line)
    {
        var parts = line.Split(',');
        var participant = new ParticipantDTO();

        participant.MeetingName = parts[0].Trim();
        participant.EntryDate = Convert.ToDateTime(parts[1].Trim());
        participant.TimeInClass = TimeSpan.Parse(parts[2].Trim());

        return participant;
    }

    private static HeaderDTO ConvertHeader(string data)
    {
        var lines = data.Split('\n');

        HeaderDTO header = new HeaderDTO();

        const string MEET = "*     Meet: ";
        const string MEETING_CODE = "*     Meeting code: ";
        const string CREATED_ON = "*     Created on ";
        const string ENDED_ON = "*     Ended on ";

        header.Name = lines[0].Trim().Replace(MEET, "");
        header.MeetingCode = lines[1].Trim().Replace(MEETING_CODE, "");
        header.StartTime = Convert.ToDateTime(lines[2].Trim().Replace(CREATED_ON, ""));
        header.EndTime = Convert.ToDateTime(lines[3].Trim().Replace(ENDED_ON, ""));

        return header;
    }

    private static bool IsHeader(string line)
    {
        return line.Trim().StartsWith("*") || line.Trim().StartsWith("Full Name");
    }
}

