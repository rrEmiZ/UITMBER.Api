using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;

        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet]

        public Task<List<DriverDto>> GetNearbyDrivers(double latitude, double longitude)
        {
            //Pobieranie id usera z tokenu
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);


            return _driverRepository.GetNearbyDrivers(latitude, longitude);
        }
    }
}
