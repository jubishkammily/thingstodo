using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThingsToDoApi.Data;
using ThingsToDoApi.Interfaces;
using ThingsToDoApi.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // services.AddSingleton<PresenceTracker>();
            // services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<ITokenService, TokenService>();
            // services.AddScoped<IPhotoService, PhotoService>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<LogUserActivity>();
            // services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options=>{
                options.UseSqlite(config.GetConnectionString("DefaultConnecton"));
            });

            return services;
        }
    }
}