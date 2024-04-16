namespace APAdmin.Application;

public abstract class ResponseBase
{
    protected ResponseBase(Guid id)
    {
        Id = id;
        Date = DateTime.UtcNow;
    }

    public Guid Id { get; set; }

    public DateTime Date { get; set; }
}
