using APAdmin.Domain;
using APAdmin.Domain.ClassAttendanceModule;
using APAdmin.Domain.TeamModule;
using APAdmin.Domain.StudentModule;
using APAdmin.Infra.Database;
using APAdmin.Infra.Database.ClassAttendanceModule;
using APAdmin.Infra.Database.TeamModule;
using APAdmin.Infra.Database.StudentModule;

namespace APAdmin.IntegrationTests;

public class IntegrationTestRepository
{
    protected ITeamRepository classRepository;
    protected IStudentRepository studentRepository;
    protected IClassAttendanceRepository attendanceRepository;

    protected IUnitOfWork dataContext;

    public IntegrationTestRepository()
    {
        string connectionString = GetConnectionString();           

        ConfigRepositories(connectionString);

        ConfigNBuilderPersistence();
    }

    private void ConfigRepositories(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<APAdminDbContext>();

        optionsBuilder.UseSqlServer(connectionString);

        dataContext = new APAdminDbContext(optionsBuilder.Options);

        classRepository = new TeamRepositoryOrm(dataContext);
        studentRepository = new StudentRepositoryOrm(dataContext);
        attendanceRepository = new ClassAttendanceRepositoryOrm(dataContext);
    }

    private void ConfigNBuilderPersistence()
    {
        BuilderSetup.SetCreatePersistenceMethod<Team>((team) =>
        {
            classRepository.Create(team);
            dataContext.CommitChanges();
        });

        BuilderSetup.SetCreatePersistenceMethod<Student>((student) =>
        {
            studentRepository.Create(student);
            dataContext.CommitChanges();
        });

        BuilderSetup.SetCreatePersistenceMethod<ClassAttendance>((attendance) =>
        {
            attendanceRepository.Create(attendance);
            dataContext.CommitChanges();
        });           
    }

    protected static string GetConnectionString()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("SqlServer");

        return connectionString;
    }
}