using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;

namespace UITMBER.Api.Repositories.Auth
{
    public interface IClientRepository
    {
        Task<bool> UpdateProfilePhoto(int userId, string base64Photo);
        Task<ClientProfileDto> GetUserProfile(int userId);
    }
}
