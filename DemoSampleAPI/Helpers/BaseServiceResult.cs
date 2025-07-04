using System;
using System.Net;

namespace DemoSampleAPI.Helpers;

public class ResultService<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
    public T? Data { get; set; }
}

public class ResultService
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
}

public static class BaseServiceResult
{
    public static ResultService Ok(string message) => new() { StatusCode = (int)HttpStatusCode.OK, Message = message };
    public static ResultService Bad(string message) => new() { StatusCode = (int)HttpStatusCode.BadRequest, Message = message };
    public static ResultService Error(string message) => new() { StatusCode = (int)HttpStatusCode.InternalServerError, Message = message };
}

public static class BaseServiceResult<T>
{
    public static ResultService<T?> Ok(string message, T? data) => new() { StatusCode = (int)HttpStatusCode.OK, Message = message, Data = data };
    public static ResultService<T> Bad(string message, T? data) => new() { StatusCode = (int)HttpStatusCode.BadRequest, Message = message, Data = data };
    public static ResultService<T> Error(string message, T? data) => new() { StatusCode = (int)HttpStatusCode.InternalServerError, Message= message, Data = data }; 
}
