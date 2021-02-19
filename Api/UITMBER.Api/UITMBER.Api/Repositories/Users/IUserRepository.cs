using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Users.Dto;

namespace UITMBER.Api.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetList();

        Task<bool> SetAsDriver(long newDriverId);

    }
}
