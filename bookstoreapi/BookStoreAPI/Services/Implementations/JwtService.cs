using BookStore.API.Configuration;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.API.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtSettings> _jwtConfiguration;
        public JwtService(IOptions<JwtSettings> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration ?? throw new ArgumentNullException(nameof(jwtConfiguration));
        }

        public SigningCredentials GetSigningCredentials()
        {
            var KeyEncoded = Encoding.UTF8.GetBytes(_jwtConfiguration.Value.SecurityKey);
            var secret = new SymmetricSecurityKey(KeyEncoded);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public List<Claim> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                 issuer: _jwtConfiguration.Value.ValidIssuer,
                 audience: _jwtConfiguration.Value.ValidAudience,
                 claims: claims,
                 expires: DateTime.Now.AddDays(Convert.ToDouble(_jwtConfiguration.Value.ExpiryInMinutes)),
                 signingCredentials: signingCredentials
                );
            return tokenOptions;
        }
    }
}
