using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTApp.Helpers
{
    public static class JwtHelper
    {

        private const string SECRET_KEY = "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest";
        public static readonly SymmetricSecurityKey SINGIN_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateToken()
        {
            var credentials = new SigningCredentials(SINGIN_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            DateTime expiry = DateTime.UtcNow.AddMinutes(60);

            int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
            {
                {"sub", "testsubject" },
                 {"Name", "test" },
                  {"email", "test@test.com" },
                   {"exp", ts},
                    {"iss", "http://localhost:44362" },
                    {"aud", "http://localhost:44362" }
            };

            var sectoken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(sectoken);

            return token;



        }
    }
}
