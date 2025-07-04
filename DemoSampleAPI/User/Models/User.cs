using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DemoSampleAPI.User.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string TelCode { get; set; }
    public string Telephone { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set;}
    public bool IsAdmin { get; set; } = false;
}
