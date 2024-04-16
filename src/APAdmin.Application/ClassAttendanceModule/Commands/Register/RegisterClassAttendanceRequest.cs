namespace APAdmin.Application.ClassAttendanceModule.Commands.Register;

public class RegisterClassAttendanceRequest : RequestBase, IRequest<Result<RegisterClassAttendanceResponse>>
{
    private readonly byte[] selectedFile;

    public RegisterClassAttendanceRequest(byte[] selectedFile)
    {
        this.selectedFile = selectedFile;
    }

    public RegisterClassAttendanceDTO GetRegisterClassAttendance()
    {
        return RegisterClassAttendanceCsvReader.ConvertFile(selectedFile);
    }
}