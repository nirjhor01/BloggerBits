using System;
using BloggerBits.Mappers;
using BloggerBits.Repositories;
using BloggerBits.Repositories.Auth;
using BloggerBits.Repositories.Contents;
using BloggerBits.Services.Auth;
using BloggerBits.Services.Contents;
using BloggerBits.Services.Notifications;
using BloggerBits.Services.Tokens;

namespace BloggerBits.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        // Generic Repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));



        //Contens
        services.AddScoped<IContenService, ContentService>();
        services.AddScoped<IContentRepository, ContentRepository>();

        //Auth
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        //jwt
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        //notificationClient 
        services.AddScoped<INotificationClientGrpcService,NotificationClientGrpcService>();


        
        return services;
    }

}
