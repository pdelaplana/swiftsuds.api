namespace SwiftSuds.Application;
public readonly struct Result<TValue, TError>
{
    public readonly TValue Value;
    public readonly TError Error;

    private Result(TValue v, TError e, bool success)
    {
        Value = v;
        Error = e;
        IsOk = success;
    }

    public bool IsOk { get; }

    public static Result<TValue, TError?> Ok(TValue v)
    {
        return new Result<TValue, TError?>(v, default, true);
    }

    public static Result<TValue?, TError> Fail(TError e)
    {
        return new Result<TValue?, TError>(default, e, false);
    }

    public static implicit operator Result<TValue, TError>(TValue v) => new(v, default!, true);
    public static implicit operator Result<TValue, TError>(TError e) => new(default!, e, false);

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<TError, TResult> failure) =>
        IsOk ? success(Value) : failure(Error);
}
