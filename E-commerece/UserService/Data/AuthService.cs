using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Models;

namespace UserService.Data
{
    public class AuthService
    {
        //this method generates a token using private key to create a JWT
        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var PrivateKey = config.GetSection("PrivateKey").Value;

            //uses private key to start the token
            var key = Encoding.ASCII.GetBytes(PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            //describes the attributes inside the payload 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            //adding email is enough since email is definatly unqiue if there is no email we shall use id to uniqly identify the payload
            //this is responsible for generating the payload inside the token
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));

            foreach (var role in user.Roles)
                claims.AddClaim(new Claim(ClaimTypes.Role, role));

            return claims;
        }
    }
}
