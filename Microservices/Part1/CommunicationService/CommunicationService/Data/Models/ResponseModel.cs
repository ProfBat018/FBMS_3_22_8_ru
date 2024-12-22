namespace CommunicationService.Models;

public class ResponseModel<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set;}
    public string ErrorCode { get; set; }
    public object Metadata { get; set; }

    public static ResponseModel<T> SuccessResponse(T data, string message = "", object metadata = null)
    {
        return new ResponseModel<T>
        {
            Success = true,
            Message = message,
            Data = data,
            Metadata = metadata
        };
    }
    public static ResponseModel<T> ErrorResponse(string message, string errorCode = null)
    {
        return new ResponseModel<T>
        {
            Success = false,
            Message = message,
            ErrorCode = errorCode
        };
    }
}