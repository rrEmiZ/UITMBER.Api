using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Drivers;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : ControllerBase
    {
        private IDriverRepository _driverRepository;

        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet]
        public Task<List<DriverDto>> GetNearbyDrivers(double latitude, double longitude)
        {
            return _driverRepository.GetNearbyDrivers(latitude, longitude);
        }

    }
}
