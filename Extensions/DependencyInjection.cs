using System;
using BloggerBits.Mappers;
using BloggerBits.Repositories;
using BloggerBits.Repositories.Contents;
using BloggerBits.Services.Contents;

namespace BloggerBits.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services)
    {
        // Generic Repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        // Specific Repositories
        services.AddScoped<IContentRepository, ContentRepository>();

        // Services
        services.AddScoped<IContenService, ContentService>();

        return services;
    }

}
