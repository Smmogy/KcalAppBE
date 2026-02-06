using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KcalAppBE.Services;

namespace KcalAppBE.Auth
{
    public interface IJwtService
    {
        Task<(bool valid, JwtSecurityToken? token)> ValidateToken(string token, bool validateLifetime = true);
        JwtSecurityToken? ParseToken(string token);
        string GenerateToken(TimeSpan lifespan, params Claim[] claims);
    }
    public class JwtService : IJwtService
    {
        private string _token;
        public JwtService(IConfigurationService configurationService)
        {
            this._token- = configurationService.Get<string>("JwtSecret");
        }
        public async Task<(bool valid, JwtSecurityToken? token)> ValidateToken(string token, bool validateLifetime = true)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_token);
                var result = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = validateLifetime,
                    ClockSkew = TimeSpan.Zero,
                });

                if (!result.IsValid)
                    return (false, null);

                return (true, result.SecurityToken as JwtSecurityToken);
            }
            catch
            {
                return (false, null);
            }
        }
        public JwtSecurityToken? ParseToken(string token) {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.ReadJwtToken(token);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string GenerateToken(TimeSpan lifespan, params Claim[] claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_t);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(lifespan),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
