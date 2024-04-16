namespace APAdmin.IntegrationTests;

public class IntegrationTestHandler<THandler> : IntegrationTestRepository
{
    protected ILogger<THandler> logger;

    public IntegrationTestHandler()
    {
        logger = new LoggerFactory().CreateLogger<THandler>();
    }
}
