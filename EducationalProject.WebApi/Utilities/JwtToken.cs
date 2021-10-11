using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EducationalProject.WebApi.Utilities
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "mysecretkey123mysecretkey123";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken()
        {
            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            DateTime Expiry = DateTime.UtcNow.AddDays(1);

            int ts = (int) (Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
           {
             {"sub","testSubject"}, 
             {"Name","Zahid"},
             {"email","zahiddemirtas@dgpays.com"},
             {"exp",ts},
             {"iss","http://localhost:44312"},
             {"aud","http://localhost:44312"},
           };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken);

            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");

            return tokenString;
        }
    }
}
