using Microsoft.IdentityModel.Tokens;
using Ploomers_Advogados.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ploomers_Advogados.Services
{
    public class TokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[] {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASFLKSDMGLM+654F65SD4F4FS65D4F65SD4FS6D54FWE65R4SD6F46F5G4BV6N54VBN"));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
