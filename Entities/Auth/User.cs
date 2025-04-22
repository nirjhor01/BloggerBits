using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace BloggerBits.Entities.Auth;
[Table("User")]
public class User : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;

    public void SetPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        PasswordHash = passwordHasher.HashPassword(this, password);
    }

    public bool VerifyPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(this, PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }

    public bool IsEmailConfirmed { get; set; } = false;
    public string? EmailVerificationToken { get; set; }
    public DateTime? TokenExpiresAt { get; set; }

}
