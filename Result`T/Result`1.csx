using System;

public class Result
{
    public bool IsSuccess { get; }

    public string FailMessage { get; }

    protected Result(bool isSuccess, string failMessage)
    {
        if (isSuccess && failMessage != null || !isSuccess && failMessage == null)
        {
            throw new InvalidOperationException($"Can't initialize an instance of {nameof(Result)} type.");
        }

        IsSuccess = isSuccess;
        FailMessage = failMessage;
    }

    public static Result CreateFail(string failMessage)
    {
        return new Result(false, failMessage);
    }

    public static Result<T> CreateFail<T>(string failMessage)
    {
        return new Result<T>(default(T), false, failMessage);
    }

    public static Result CreateSuccess()
    {
        return new Result(true, null);
    }

    public static Result<T> CreateSuccess<T>(T value)
    {
        return new Result<T>(value, true, null);
    }
}

public class Result<T> : Result
{
    public T Value { get; }

    protected internal Result(T value, bool isSuccess, string failMessage) :
        base(isSuccess, failMessage)
    {
        Value = value;
    }
}