using System;
using AutoMapper;
using BloggerBits.DTOS.Auth.Request;
using BloggerBits.DTOS.Auth.Response;
using BloggerBits.Entities.Auth;
using BloggerBits.Repositories.Auth;
using BloggerBits.Services.Tokens;

namespace BloggerBits.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;

    public AuthService(IAuthRepository authRepository, IMapper mapper, IJwtTokenService jwtTokenService)
    {
        _authRepository = authRepository;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
    }
    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        try
        {
            var res = _authRepository.GetByCondition(x => x.Email == loginRequest.UseNameOrEmail).FirstOrDefault();
            var isPasswordValid = res.VerifyPassword(loginRequest.Password);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Email or Password is Invalid");
            }
            var token = _jwtTokenService.GenerateToken(res);
            var responseModel = _mapper.Map<LoginResponse>(res);
            responseModel.Token = token;
            return responseModel;
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    public async Task<bool> Register(RegistrationRequest registrationRequest)
    {
        try
        {
            var UserEntity = _mapper.Map<User>(registrationRequest);
            UserEntity.SetPassword(registrationRequest.Password);
            UserEntity.FullName = registrationRequest.FirstName + " " + registrationRequest.LastName;
            await _authRepository.AddAsync(UserEntity);
            await _authRepository.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
