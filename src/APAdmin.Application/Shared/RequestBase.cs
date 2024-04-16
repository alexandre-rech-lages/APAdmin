namespace APAdmin.Application;

public abstract class RequestBase
{
    public RequestBase()
    {
        RequestId = Guid.NewGuid();
    }

    public Guid RequestId { get; set; }
}
