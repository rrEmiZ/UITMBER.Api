using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Repositories.Drivers
{
    public class DriverRepository: IDriverRepository
    {
        private readonly UDbContext _context;
        public DriverRepository(UDbContext context)
        {
            _context = context;
        }

        public Task<List<DriverDto>> GetNearbyDrivers(double latitude,double longitude)
        {
            return _context.Users.Where(x => x.IsDriver && x.IsWorking)
                .Select(x => new DriverDto()
                {
                    id = x.Id,
                    Lat = x.Lat,
                    Long = x.Long
                }).ToListAsync();
        }
    }
}
