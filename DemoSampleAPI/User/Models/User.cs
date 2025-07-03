using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DemoSampleAPI.User.Models;

public class UserModel
{
    public int Id { get; set; } = 0;
    [Required]
    [MinLength(6, ErrorMessage = "Please provide more than six character")]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string TelCode { get; set; }
    [Required]
    public string Telephone { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set;}
    public bool IsAdmin { get; set; } = false;
}
