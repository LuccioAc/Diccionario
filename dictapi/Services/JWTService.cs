using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace dictapi.Services
{
    public class JWTService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;

        public JWTService(IConfiguration config)
        {
            _secret = config["Jwt:Key"];
            _issuer = config["Jwt:Issuer"];
            _audience = config["Jwt:Audience"];
        }

        public string GenerateToken(string codeusr, bool rol)
        {
            var claims = new[]
            {
            //new Claim(ClaimTypes.Name, codeusr),
            new Claim("codeusr", codeusr),
            new Claim(ClaimTypes.Role, rol ? "Admin" : "User")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}