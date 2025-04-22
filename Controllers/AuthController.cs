using BloggerBits.DTOS.Auth.Request;
using BloggerBits.DTOS.Auth.Response;
using BloggerBits.Entities.Auth;
using BloggerBits.Helper;
using BloggerBits.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BloggerBits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var res = await  _authService.Login(loginRequest);
            if(res != null)
            {
                return Ok(ApiResponse<LoginResponse>.Ok(Helper.UiMessage.DataFound,res));
            }
            return BadRequest(ApiResponse<LoginResponse>.Fail(Helper.UiMessage.DataNotFound));
            
        }
        [HttpPost("register")]
        public async Task<IActionResult>Register(RegistrationRequest registrationRequest)
        {
            if(await _authService.Register(registrationRequest))
            {
                return  Ok(ApiResponse<bool>.Ok(UiMessage.DataSaved));
            }
            return BadRequest(ApiResponse<bool>.Fail(UiMessage.OperationFailed));
        }
    }
}
