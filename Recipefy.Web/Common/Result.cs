namespace Recipefy.Web.Common;

public class Result
{
    public bool Succeeded { get; }
    public IEnumerable<string> Errors { get; }

    protected Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors ?? Array.Empty<string>();
    }

    public static Result Success()
        => new Result(true, Array.Empty<string>());

    public static Result Failure(params string[] errors)
        => new Result(false, errors);
}

public class Result<TData> : Result
{
    public TData Data { get; }

    protected internal Result(bool succeeded, TData data, IEnumerable<string> errors)
        : base(succeeded, errors)
    {
        Data = data;
    }

    public static Result<TData> Success(TData data)
        => new Result<TData>(true, data, Array.Empty<string>());

    public static Result<TData> Failure(params string[] errors)
        => new Result<TData>(false, default!, errors);
}