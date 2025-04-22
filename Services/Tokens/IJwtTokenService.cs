using System;
using BloggerBits.Entities.Auth;

namespace BloggerBits.Services.Tokens;

public interface IJwtTokenService
{
   public string GenerateToken(User user);

}
