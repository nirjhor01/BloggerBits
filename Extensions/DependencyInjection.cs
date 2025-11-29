using BloggerBits.Repositories;
using BloggerBits.Repositories.Auth;
using BloggerBits.Repositories.Categories;
using BloggerBits.Repositories.Contents;
using BloggerBits.Services.Auth;
using BloggerBits.Services.Categories;
using BloggerBits.Services.Contents;
using BloggerBits.Services.Tokens;

namespace BloggerBits.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        // Generic Repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        //Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();

        //Contens
        services.AddScoped<IContenService, ContentService>();
        services.AddScoped<IContentRepository, ContentRepository>();

        //Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        //jwt
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }

}
