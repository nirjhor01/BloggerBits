using System;
using System.ComponentModel.DataAnnotations;

namespace BloggerBits.DTOS.Auth.Request;

public class LoginRequest
{
    [Required(ErrorMessage = "Username or Email is required.")]
    public string UseNameOrEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    public string? TwoFactorCode { get; init; }

    public string? TwoFactorRecoveryCode { get; init; }

}
