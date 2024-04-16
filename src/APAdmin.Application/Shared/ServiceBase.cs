namespace APAdmin.Application;

public abstract class ServiceBase<TRequest, THandler, TValidator>
    where TValidator : AbstractValidator<TRequest>, new()
{
    protected readonly ILogger<THandler> logger;

    protected ServiceBase(ILogger<THandler> logger)
    {
        this.logger = logger;
    }

    protected virtual Result Validate(TRequest obj)
    {
        var validator = new TValidator();

        var validationResult = validator.Validate(obj);

        var errors = new List<Error>();

        foreach (var validationFailure in validationResult.Errors)
        {
            errors.Add(new Error(validationFailure.ErrorMessage));
        }

        if (errors.Any())
            return Result.Fail(errors);

        return Result.Ok();
    }
}
