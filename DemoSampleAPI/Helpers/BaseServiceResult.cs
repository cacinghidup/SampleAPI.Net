using System;
using System.Net;

namespace DemoSampleAPI.Helpers;

public class ResultService<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
    public object? Data { get; set; } = null;
}

public class ResultService
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
}

public static class BaseServiceResult
{
    public static ResultService Ok(string message = "Success") => new() { StatusCode = (int)HttpStatusCode.OK, Message = message };
    public static ResultService Bad(string message = "Bad Request") => new() { StatusCode = (int)HttpStatusCode.BadRequest, Message = message };
    public static ResultService Error(string message = "Internal Server Error! PLease Try Again Later!") => new() { StatusCode = (int)HttpStatusCode.InternalServerError, Message = message };
}

public static class BaseServiceResult<T>
{
    public static ResultService<T> Ok(T? data, string message = "Success") => new() { StatusCode = (int)HttpStatusCode.OK, Message = message, Data = data };
    public static ResultService<T> Bad(T? data, string message = "Bad Request") => new() { StatusCode = (int)HttpStatusCode.BadRequest, Message = message, Data = data };
    public static ResultService<T> Error(T? data, string message = "Internal Server Error! PLease Try Again Later!") => new() { StatusCode = (int)HttpStatusCode.InternalServerError, Message= message, Data = data };

}
