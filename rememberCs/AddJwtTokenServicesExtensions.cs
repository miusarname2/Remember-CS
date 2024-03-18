using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using rememberCs.Models.DataModels;

namespace rememberCs
{
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection services,IConfiguration configuration)
        {
            // Add setting jwt

            var bindJwtSetting = new JwtSettings();

            configuration.Bind("JsonWebTokenKeys", bindJwtSetting);

            services.AddSingleton(bindJwtSetting);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters() {

                    ValidateIssuerSigningKey = bindJwtSetting.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSetting.IssuerSigningKey)),
                    ValidateIssuer = bindJwtSetting.validateIUssuer,
                    ValidIssuer = bindJwtSetting.ValidIssuer,
                    ValidateAudience = bindJwtSetting.ValidateAudience,
                    ValidAudience = bindJwtSetting.ValidAudience,
                    RequireExpirationTime = bindJwtSetting.RequireExpirationTime,
                    ValidateLifetime = bindJwtSetting.ValidateLifetime,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });

        }
    }
}
