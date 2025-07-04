using System;
using System.ComponentModel.DataAnnotations;

namespace DemoSampleAPI.User.DTO;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MinLength(6, ErrorMessage = "Please provide more than 6 character!")]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(10, ErrorMessage = "The phone number must be at least 10 characters long.")]
    public string Telephone { get; set; } = string.Empty;

    [Required]
    public string TelCode { get; set; } = string.Empty;
}
