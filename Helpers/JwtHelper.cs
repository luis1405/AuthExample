using AuthenticationAndAuthorization.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAndAuthorization.Helpers
{
    public static class JwtHelper
    {
        public static string GenerarToken(User user, JwtAuthenticationSettings jwtAuthenticationSettings)
        {
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("nombre", user.Nombre),
                new Claim("apellido", user.Apellido),
                new Claim("mail", user.Email),
                new Claim("genero", user.Genero),
            };
            foreach (var role in user.Role)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthenticationSettings.IssuerSigningKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credential,
                Issuer = jwtAuthenticationSettings.ValidIssuer,
                Audience = jwtAuthenticationSettings.ValidAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
