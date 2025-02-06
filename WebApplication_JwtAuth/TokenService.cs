using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication_JwtAuth
{
    public class TokenService
    {
        public const string SECRETKEY = "57A9890E-11DE-4A82-9B99-00A425C17BE2";
        public const string ISSUER = "http://localhost:5000";
        public const string AUDIENCE = "http://localhost:5000";

        public static string GenerateToken(string username, string userId ="99", string role ="user")
        {
            byte[] key = Encoding.UTF8.GetBytes(SECRETKEY);
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(ISSUER, AUDIENCE, claims, null, DateTime.Now.AddDays(30), credentials); 
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


            return token;
        }
    }
}
