namespace APAdmin.Infra.Database;

public abstract class RepositoryBase<TEntity> where TEntity : EntityBase<TEntity>
{
    protected DbSet<TEntity> registers;
    private readonly APAdminDbContext dbContext;

    public RepositoryBase(IUnitOfWork contextData)
    {
        dbContext = (APAdminDbContext)contextData;
        registers = dbContext.Set<TEntity>();
    }

    public virtual TEntity Create(TEntity newRegister)
    {
        registers.Add(newRegister);

        return newRegister;
    }

    public virtual TEntity Update(TEntity register)
    {
        registers.Update(register);

        return register;
    }

    public virtual bool Delete(TEntity register)
    {
        registers.Remove(register);

        return true;
    }

    public virtual TEntity GetById(Guid id)
    {
        return registers.Find(id);
    }

    public virtual List<TEntity> GetAll()
    {
        return registers.ToList();
    }
}
