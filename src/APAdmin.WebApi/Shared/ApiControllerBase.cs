namespace APAdmin.WebApi;

public class ApiControllerBase : ControllerBase
{
    protected readonly IMediator mediator;

    public ApiControllerBase(IMediator mediator)
    {
        this.mediator = mediator;
    }

    protected ObjectResult Execute<TResponse>(Result<TResponse> result)
    {
        if (result.IsFailed)
        {
            return BadRequest(new
            {
                success = false,
                errors = result.Errors.Select(x => x.Message)
            });
        }

        return Ok(new
        {
            success = true,
            data = result.Value
        });
    }
}