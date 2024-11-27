namespace DotNet8.EmailServiceMinimalApi.Models;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public bool IsError => !IsSuccess;
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static Result<T> SuccessResult(T data, string message = "Success")
    {
        return new Result<T> { IsSuccess = true, Data = data, Message = message };
    }

    public static Result<T> SuccessResult(string message = "Success")
    {
        return new Result<T> { IsSuccess = true, Message = message };
    } 
    
    public static Result<T> FailureResult(string message = "Fail")
    {
        return new Result<T> { IsSuccess = false, Message = message };
    }
    
}