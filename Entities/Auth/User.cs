using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace BloggerBits.Entities.Auth;

public class User: BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty; // User's full name

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty; // User's email

    private string _passwordHash = string.Empty;

    public string PasswordHash{get { return _passwordHash; }}

    public void SetPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        _passwordHash = passwordHasher.HashPassword(this, password); // Store hashed password
    }

    public bool VerifyPassword(string password)
    {
        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(this, _passwordHash, password);
        return result == PasswordVerificationResult.Success; // Check if password matches
    }

    public bool IsEmailConfirmed { get; set; } = false;
    public string? EmailVerificationToken { get; set; }
    public DateTime? TokenExpiresAt { get; set; }

}
