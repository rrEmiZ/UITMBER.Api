using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Repositories.Drivers
{
    public class DriverRepository : IDriverRepository
    {
        private readonly UDbContext _context;

        public DriverRepository(UDbContext context)
        {
            _context = context;
        }

        public async Task<List<DriverDto>> GetDrivers()
        {
            return await _context.Users.Where(x => x.IsWorking && x.IsDriver)
                 .Select(x => new DriverDto()
                 {
                     Id = x.Id,
                     Email = x.Email,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Lat = x.Lat,
                     Long = x.Long,
                     PhoneNumber = x.PhoneNumber,
                     Photo = x.Photo
                 }).ToListAsync();
        }

        public Task<List<DriverDto>> GetNearbyDrivers(double latitude, double longitude, long userId)
        {
            //TODO: Nearby filter
            return _context.Users.Where(x => x.IsDriver && x.IsWorking && x.Lat == latitude && x.Long == longitude && x.Id != userId)
                .Select(x => new DriverDto()
                {
                    Id = x.Id,
                    Lat = x.Lat,
                    Long = x.Long
                }).ToListAsync();

        }

        public Task<User> GetProfile(long id)
        {
            return _context.Users.Where(x => x.Id == id)
                .Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Photo = x.Photo,
                    PhoneNumber = x.PhoneNumber,
                    IsDriver = x.IsDriver,
                    Lat = x.Lat,
                    Long = x.Long
                }).FirstOrDefaultAsync();
        }

    }
}
