namespace APAdmin.Domain;

public abstract class EntityBase<T>
{
    public EntityBase()
    {
        Id = SequentialGuid.NewGuid();
    }

    public Guid Id { get; set; }
}
