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

    public class ClientRepository : IClientRepository
    {
        private readonly UDbContext _dbContext;

        public ClientRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ClientProfileDto> GetUserProfile(int userId)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);
            
            //user not found in db
            if (user == null)
                return null;

            var resultModel = ClientProfileDto.FromAccountProfileDto(user);

            //Get client rate
            var clientRate = await _dbContext.Orders.AsNoTracking().Where(x => x.UserId == userId).AverageAsync(x => x.ClientRate);
            resultModel.ClientRate = clientRate;

            return resultModel;
        }

        public async Task<bool> UpdateProfilePhoto(int userId, string base64Photo)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);

            //User not found in db
            if (user == null)
                return false;

            user.Photo = "";//base64Photo;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
