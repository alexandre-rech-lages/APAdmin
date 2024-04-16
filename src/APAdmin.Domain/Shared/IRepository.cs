namespace APAdmin.Domain.Shared;

public interface IRepository<T> where T : EntityBase<T>
{
    T Create(T register);
    
}
