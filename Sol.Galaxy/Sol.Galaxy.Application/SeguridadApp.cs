using Microsoft.IdentityModel.Tokens;
using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public class SeguridadApp : ISeguridadApp
    {
        public UserAutenticaResponse Autentica(UserAutenticaRequest userAutenticaRequest)
        {
            if (!(userAutenticaRequest.User == "riza" && userAutenticaRequest.Password == "1234"))
            {

                return null;
            }

            //  throw new NotImplementedException();

    
            string semila = "Estaesunaclavelargacumplerequisitode256bitsEstaesunaclavelargacumplerequisitode256bits";
            byte[] semilaBytes = Encoding.UTF8.GetBytes(semila);
            SymmetricSecurityKey key = new SymmetricSecurityKey(semilaBytes);

            //Paso 2
            var encripta = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Paso 3 crear el Payload
            var misClaims = new[]
            {
                new Claim("user",userAutenticaRequest.User),
                new Claim("rol","admin"),
            };

            //Paso 4 Generador Tokens
            JwtSecurityToken generador = new JwtSecurityToken(
                claims: misClaims,
                signingCredentials: encripta,
                expires: DateTime.Now.AddMinutes(5),
                issuer: "galaxy.com",
                audience:"galaxy"                             
                );

            string tk=new JwtSecurityTokenHandler().WriteToken(generador);
             UserAutenticaResponse response = new UserAutenticaResponse()
             {
                 Token = tk,
                 Id=1
             };  
            return response;

        }
    }
}
