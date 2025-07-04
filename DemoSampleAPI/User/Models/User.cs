using System;
using System.ComponentModel.DataAnnotations;

namespace DemoSampleAPI.User.Models;

public class UserModel
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string Password { get; set; } = string.Empty;
    public required string Email { get; set; }
    public required string TelCode { get; set; }
    public required string Telephone { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set;}
    public bool IsAdmin { get; set; } = false;
}
