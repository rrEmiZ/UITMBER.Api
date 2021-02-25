using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Users.Dto;

namespace UITMBER.Api.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UDbContext _context;

        public UserRepository(UDbContext context)
        {
            _context = context;
        }


        public Task<List<UserDto>> GetList()
        {
            return _context.Users.Select(x => new UserDto()
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Photo = x.Photo
            }).ToListAsync();
        }

        public async Task<bool> SetAsDriver(long newDriverId)
        {
            try
            {
                var usr = await _context.Users.Where(x => x.Id == newDriverId).FirstOrDefaultAsync();

                if (usr != null)
                {
                    usr.IsDriver = true;
                    usr.Lat = 0;
                    usr.Long = 0;

                    _context.Users.Update(usr);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        public async Task<List<UserApplication>> GetAllApplications()
        {

            try
            {
                var aplicationsList = await _context.UserApplications
                .ToListAsync();

                return aplicationsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task SetAccepted(long id)
        {
            var app = await _context.UserApplications.Where(x => x.Id == id).FirstOrDefaultAsync();
            app.Accepted = true;
            _context.UserApplications.Update(app);
            await _context.SaveChangesAsync();

        }
    }
}
