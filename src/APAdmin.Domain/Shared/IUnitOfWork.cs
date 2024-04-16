namespace APAdmin.Domain;

public interface IUnitOfWork
{
    bool CommitChanges();

    bool Roolback();
}
