using Core.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Core.Security.Jwt
{
    public static class TokenGenerator
    {
        public static string Token(User user, string role)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("nmDLKAna9f9WEKPPH7z3tgwnQ433FAtrdP5c9AmDnmuJp9rzwTPwJ9yUu");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                 {
                     new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                     new Claim(JwtRegisteredClaimNames.Email, user.Email),
                     new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim (ClaimTypes.Role, role),
                 }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                Issuer = "ComparAcademy",
                Audience = "ComparAcademy"
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);

        }
    }
}
