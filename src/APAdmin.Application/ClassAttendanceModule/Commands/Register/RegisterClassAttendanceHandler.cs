using APAdmin.Domain;
using APAdmin.Domain.ClassAttendanceModule;
using APAdmin.Domain.TeamModule;
using APAdmin.Domain.StudentModule;

namespace APAdmin.Application.ClassAttendanceModule.Commands.Register;

public class RegisterClassAttendanceHandler :
    ServiceBase<RegisterClassAttendanceRequest, RegisterClassAttendanceHandler, RegisterClassAttendanceValidator>,
    IRequestHandler<RegisterClassAttendanceRequest, Result<RegisterClassAttendanceResponse>>
{
    private readonly IUnitOfWork dataContext;
    private readonly ITeamRepository teamRepository;
    private readonly IClassAttendanceRepository classAttendanceRepository;

    public RegisterClassAttendanceHandler(
        ILogger<RegisterClassAttendanceHandler> logger,
        IUnitOfWork dataContext,
        ITeamRepository teamRepository, 
        IClassAttendanceRepository classAttendanceRepository) : base(logger)
    {
        this.dataContext = dataContext;
        this.teamRepository = teamRepository;
        this.classAttendanceRepository = classAttendanceRepository;
    }

    public async Task<Result<RegisterClassAttendanceResponse>> Handle(RegisterClassAttendanceRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = Validate(request);

        if (validationResult.IsFailed)
            return await Task.FromResult(
                Result.Fail(validationResult.Errors));

        var registerClassAttendance = request.GetRegisterClassAttendance();

        var team = teamRepository.GetByYear(registerClassAttendance.Date.Year, includeStudents: true);

        if (team != null)
        {
            foreach (var student in team.Students)
            {
                var presentIn = PresentIn(registerClassAttendance, student);

                var classAttendance = new ClassAttendance(team, student, registerClassAttendance.Date, presentIn);

                classAttendanceRepository.Create(classAttendance);
            }

            dataContext.CommitChanges();
        }

        return await Task.FromResult(
            Result.Ok(
                new RegisterClassAttendanceResponse(
                    Guid.NewGuid())));
    }

    private static bool PresentIn(RegisterClassAttendanceDTO registerAttendance, Student student)    
    {                
        return registerAttendance.Participants.Exists(p => p.MeetingName == student.MeetingName);
    }
}