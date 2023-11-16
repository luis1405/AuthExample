using AuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationAndAuthorization.Config
{
    public static class JwtAuthenticationServiceExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection Services, IConfiguration Configuration)
        {
            var bindJwtAuthenticationSettings = new JwtAuthenticationSettings();
            Configuration.Bind("JwtAuthentication", bindJwtAuthenticationSettings);

            //Inyeccion del Objeto JwtAuthenticationSettings
            Services.AddSingleton(bindJwtAuthenticationSettings);

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtAuthenticationSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtAuthenticationSettings.IssuerSigningKey)),
                    ValidateIssuer = bindJwtAuthenticationSettings.ValidateIssuer,
                    ValidIssuer = bindJwtAuthenticationSettings.ValidIssuer,
                    ValidateAudience = bindJwtAuthenticationSettings.ValidateAudience,
                    ValidAudience = bindJwtAuthenticationSettings.ValidAudience,
                    RequireExpirationTime = bindJwtAuthenticationSettings.RequireExpirationTime,
                    ValidateLifetime = bindJwtAuthenticationSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1),
                };
            });
        }
    }
}
