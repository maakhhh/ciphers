using CSharpFunctionalExtensions;

namespace Ciphers;

public static class ExceptionHandler<T>
{
    public static Result<T> Execute(Func<Result<T>> action)
    {
        try
        {
            return action();
        }

        catch (Exception e)
        {
            return Result.Failure<T>(e.Message);
        }
    }
}