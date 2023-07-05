using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SecurityLayer.Dal;

public class BuildToken
{
    public string CreateToken()
    {
        var bytes = Encoding.UTF8.GetBytes("resumedemobydejkoveci");
        SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost",
            notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials);
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }
}