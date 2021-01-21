using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Repositories.Drivers
{
    public interface IDriverRepository
    {
        Task<List<DriverDto>> GetNearbyDrivers(double latitude, double longitude);
    };
}
