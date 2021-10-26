using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Passenger.Infrastructure.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Extensions
{
    public static class JwtAuthorizationExtension
    {
        public static void AddJwtAuthorization(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var settings = serviceProvider.GetService<IOptions<JwtSettings>>().Value;

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.Audience = "http://localhost:5001/";
                    cfg.Authority = "http://localhost:5000/";
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidIssuer = settings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
        }
    }
}
