using System;
using Microsoft.AspNetCore.Mvc;

namespace DemoSampleAPI.Interfaces;

public class BaseResponseApi<T>
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}

public static class ApiResponse
{
    public static IActionResult Ok(string? message = "Success", object? data = null)
        => new OkObjectResult(new BaseResponseApi<object>
        {
            StatusCode = 200,
            Message = message,
            Data = data
        });

    public static IActionResult NotFound(string? message = "Not Found")
        => new NotFoundObjectResult(new BaseResponseApi<object>
        {
            StatusCode = 404,
            Message = message,
            Data = null
        });

    public static IActionResult BadRequest(string? message = "Bad Request")
        => new BadRequestObjectResult(new BaseResponseApi<object>
        {
            StatusCode = 400,
            Message = message,
            Data = null
        });

    public static IActionResult ServerError(string? message = "Internal Server Error")
        => new ObjectResult(new BaseResponseApi<object>
        {
            StatusCode = 500,
            Message = message,
            Data = null
        });
}