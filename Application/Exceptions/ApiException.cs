namespace Application.Exceptions;

public class ApiException : Exception
{
    public string Message { get; set; }
    public int Code { get; set; }
    
    public ApiException(string? message) : base(message)
    {
        
    }
    
    public ApiException(string message, int code)
    {
        Message = message;
        Code = code;
    }
}