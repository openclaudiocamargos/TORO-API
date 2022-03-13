using Application.Commom.Interfaces;
using Infrastructure.Options;
using Infrastructure.Persitence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProjectSettings>(configuration.GetSection("Settings"));
            services.AddDbContext<ToroDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ToroDbContext).Assembly.FullName)));
            services.AddScoped<IToroDbContext>(provider => provider.GetRequiredService<ToroDbContext>());
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["Settings:JWTAudience"],
                    ValidIssuer = configuration["Settings:JWTIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Settings:JWTSecretKey"]))
                };
            });

            return services;
        }
    }
}