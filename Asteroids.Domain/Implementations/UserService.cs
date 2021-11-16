using Asteroids.Domain.Interfaces;
using Asteroids.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Asteroids.Domain.Implementations
{
    public class UserService : IUserService
    {
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel { Id = 1, Username = " Admin@test.com", Password = "Admin@1234" },
            new UserModel { Id = 2, Username = "Client@test.com", Password = "Client@1234" }
        };

        public AuthenticateResponseModel Authenticate(AuthenticateRequestModel model, string secret)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = generateJwtToken(user, secret);

            return new AuthenticateResponseModel() { Login = model.Username, Token = token };
        }

        private string generateJwtToken(UserModel user, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
