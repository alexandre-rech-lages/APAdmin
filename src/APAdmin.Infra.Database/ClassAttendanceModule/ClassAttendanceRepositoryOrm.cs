using APAdmin.Domain.ClassAttendanceModule;

namespace APAdmin.Infra.Database.ClassAttendanceModule;

public class ClassAttendanceRepositoryOrm : RepositoryBase<ClassAttendance>, IClassAttendanceRepository
{
    public ClassAttendanceRepositoryOrm(IUnitOfWork contextData) : base(contextData)
    {
    }
}
