using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;

namespace UITMBER.Api.Repositories.Auth
{
    public interface IAuthenticationRepository
    {
        Task<LoginResultDto> AuthenticateAsync(string login, string password);
        string GenerateToken(LoginResultDto loginResult, AppSettings appSettings);
        Task<LoginResultDto> RegisterAsync(string email, string password, string firstName, string lastName, string phoneNumber, string photo);
    }
}
