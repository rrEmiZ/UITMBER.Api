

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;

namespace UITMBER.Api.Repositories.Auth
{

    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UDbContext _dbContext;

        public AuthenticationRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoginResultDto> AuthenticateAsync(string login, string password)
        {
            var user = await _dbContext.Users.Where(x => x.Email == login).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("Blad logowania");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Blad logowania");
            }

            return new LoginResultDto()
            {
                Success = true,
                Name = user.Email,
                Id = user.Id,
                Photo = user.Photo,
                Roles = user.IsDriver ? "Driver" : "Client"
            };
        }

        public string GenerateToken(LoginResultDto loginResult, AppSettings appSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.JWTSecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginResult.Id.ToString()),
                    new Claim("UserId", loginResult.Id.ToString()),
                    new Claim(ClaimTypes.Role, loginResult.Roles),

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = appSettings.JWTAudience,
                Issuer = appSettings.JWTIssuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginResultDto> RegisterAsync(string email, string password, string firstName, string lastName, string phoneNumber, string photo)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Email == email))
            {
                throw new Exception("Jest juz taki user");
            }

            var pwHash = BCrypt.Net.BCrypt.HashPassword(password);


            var user = new User()
            {
                Email = email,
                FirstName = firstName,
                IsDriver = false,
                IsWorking = false,
                LastName = lastName,
                Lat = 0,
                Long = 0,
                Password = pwHash,
                PhoneNumber = phoneNumber,
                Photo = photo
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new LoginResultDto()
            {
                Success = true,
                Name = user.Email,
                Id = user.Id,
                Photo = user.Photo,
                Roles = "Client"
            };
        }
    }
}
