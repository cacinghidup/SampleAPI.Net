using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DemoSampleAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoSampleAPI.Tests;

[ApiController]
[Route("api/testing")]
public class TestingApiOKController : ControllerBase
{
    [HttpGet]
    public IActionResult Test_Api_Ok()
    {
        return ApiResponse.Ok();
    }
}