using System;

namespace BloggerBits.DTOS.Auth.Request;

public class RegistrationRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password{get;set;}

}
