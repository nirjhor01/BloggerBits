using System;
using BloggerBits.Database;
using BloggerBits.Entities.Auth;

namespace BloggerBits.Repositories.Auth;

public class AuthRepository : BaseRepository<User>, IAuthRepository
{
    public AuthRepository(ApplicationDbContext context) : base(context)
    {
    }
}
