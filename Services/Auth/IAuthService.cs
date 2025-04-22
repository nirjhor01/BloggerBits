using System;
using BloggerBits.DTOS.Auth.Request;
using BloggerBits.DTOS.Auth.Response;

namespace BloggerBits.Services.Auth;

public interface IAuthService
{
    public Task<LoginResponse> Login(LoginRequest loginRequest);
    public Task<bool> Register(RegistrationRequest registrationRequest);

}
