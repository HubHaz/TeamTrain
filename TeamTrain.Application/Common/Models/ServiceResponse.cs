namespace TeamTrain.Application.Common.Models;

public class ServiceResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }

    public static ServiceResponse<T> SuccessResponse(T data, string? message = null)
        => new() { Success = true, Data = data, Message = message };

    public static ServiceResponse<T> ErrorResponse(string message, List<string>? errors = null)
        => new() { Success = false, Message = message, Errors = errors };
}

public class ServiceResponse : ServiceResponse<object>
{
    public static ServiceResponse SuccessResponse(string? message = null)
        => new() { Success = true, Message = message };

    public static new ServiceResponse ErrorResponse(string message, List<string>? errors = null)
        => new() { Success = false, Message = message, Errors = errors };
}