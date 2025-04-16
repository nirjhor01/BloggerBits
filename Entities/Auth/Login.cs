using System;
using System.ComponentModel.DataAnnotations;

namespace BloggerBits.Entities.Auth;

public class Login
{
    [Required(ErrorMessage = "Username or Email is required.")]
    public string UseNameOrEmail { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;


}
