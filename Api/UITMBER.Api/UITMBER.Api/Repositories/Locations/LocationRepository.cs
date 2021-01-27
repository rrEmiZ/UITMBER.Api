using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Locations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly UDbContext _dbContext;

        public LocationRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool SaveLocation(long id, double lat, double longitude)
        {
            User user = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Lat = lat;
                user.Long = longitude;
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
