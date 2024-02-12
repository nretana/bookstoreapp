using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookStore.API.Services.Interfaces
{
    public interface IJwtService
    {
        public SigningCredentials GetSigningCredentials();

        List<Claim> GetClaims(IdentityUser user);

        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    }
}
