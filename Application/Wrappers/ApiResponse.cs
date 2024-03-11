using System.Net;
using Application.Enums;

namespace Application.Wrappers;

public class ApiResponse<T>
{
    public ApiResponse()
    {
            
    }

    //success response
    public ApiResponse(T data, string message = null)
    {
        StatusCode = HttpStatusCode.OK;
        Message = message;
        Data = data;
    }

    //faild response
    public ApiResponse(string message, HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public ApiResponse(HttpStatusCode statusCode, ErrorCode errorCode)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public HttpStatusCode StatusCode { get; set; }
    public ErrorCode ErrorCode { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
}