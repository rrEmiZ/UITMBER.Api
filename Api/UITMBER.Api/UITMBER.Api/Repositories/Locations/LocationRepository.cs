using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Cars.Dto;
using UITMBER.Api.Repositories.Locations.Dto;

namespace UITMBER.Api.Repositories.Locations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly UDbContext _context;

        public LocationRepository(UDbContext Context)
        {
            _context = Context;
        }
        public async Task<SaveLocationDto> SaveMyLocation(long id, double latitude, double longitude)
        {
            User result = await (from p in _context.Users
                                 where p.Id == id
                                 select p).FirstOrDefaultAsync();

            result.Lat = latitude;
            result.Long = longitude;

            _context.Users.Update(result);
            await _context.SaveChangesAsync();

            return new SaveLocationDto()
            {
                Success = true,
                Latitude = result.Lat,
                Longitude = result.Long
            };
        }

    }
}
