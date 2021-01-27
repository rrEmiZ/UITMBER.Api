using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.Repositories.Drivers;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Controllers
{

    /// <summary>
    /// Author : LipaMar
    /// </summary>

    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;
        private readonly AppSettings _appSettings;

        public DriverController(IDriverRepository driverRepository, AppSettings appSettings)
        {
            _driverRepository = driverRepository;
            _appSettings = appSettings;
        }

        [HttpGet]
        public Task<List<DriverDto>> GetNearbyDrivers(double latitude, double longitude)
        {
            //Pobieranie id usera z tokenu
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);


            return _driverRepository.GetNearbyDrivers(latitude, longitude, userId);
        }

        [HttpGet]
        public Task<User> GetProfile()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return _driverRepository.GetProfile(userId);
        }
    }
}
