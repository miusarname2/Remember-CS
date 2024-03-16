using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using rememberCs.Models.DataModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace rememberCs.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAcccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("Id",userAcccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAcccounts.UserName),
                new Claim(ClaimTypes.Email, userAcccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            if(userAcccounts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }else if (userAcccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims (this UserTokens userAcccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAcccounts,Id);
        }

        public static UserTokens GenTokenKey(UserTokens model,JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                // Obtain Secret Key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                // Expire in a day

                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validity ofour token

                userToken.Validity = expireTime.TimeOfDay;

                // Generate jwt

                var jwToken = new JwtSecurityToken(
                    
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model,out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials:  new SigningCredentials(
                        
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256

                        )

                    );

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuId = Id;
                return userToken;
            }catch(Exception ex)
            {
                throw new Exception("Error gerating JWT", ex);
            }
        }

    }
}
