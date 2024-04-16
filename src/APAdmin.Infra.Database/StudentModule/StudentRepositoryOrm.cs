using APAdmin.Domain.StudentModule;

namespace APAdmin.Infra.Database.StudentModule;

public class StudentRepositoryOrm : RepositoryBase<Student>, IStudentRepository
{
    public StudentRepositoryOrm(IUnitOfWork contextData) : base(contextData)
    {
    }

    public List<Student> GetAll(bool includeAttendances = false)
    {
        if (includeAttendances)        
            return registers
                .Include(x => x.ClassesAttendances)
                .ToList();

        return registers
            .ToList();
    }
}