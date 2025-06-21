namespace N30A.Suite.Data;

public sealed class DbResult<T>
{
    public bool Succeeded { get; private set; }
    public T? Data { get; private set; }
    public Exception? Exception { get; private set; }
    
    private DbResult(bool succeeded, T? data, Exception? exception)
    {
        Succeeded = succeeded;
        Data = data;
        Exception = exception;
    }

    public static DbResult<T> Success(T data)
    {
        return new DbResult<T>(true, data, null);
    }

    public static DbResult<T> Failure(Exception exception, T? data = default) 
    {
        return new DbResult<T>(false, data, exception);
    }
}
