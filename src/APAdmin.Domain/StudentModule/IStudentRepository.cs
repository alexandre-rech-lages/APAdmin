namespace APAdmin.Domain.StudentModule;

public interface IStudentRepository : IRepository<Student>
{
    List<Student> GetAll(bool includeAttendances = false);
}
