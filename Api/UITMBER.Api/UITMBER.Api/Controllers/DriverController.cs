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
        public async Task<IEnumerable<DriverDto>> GetNerbyDriveresAsync(double latitude, double longitude)
        {

            List<DriverDto> drivers = await _driverRepository.GetDrivers();
            return drivers;
        }

        [HttpGet]
        public async Task<DriverDto> GetProfile(int id)
        {
            List<DriverDto> drivers = await _driverRepository.GetDrivers();
            return drivers.Where(driver => driver.Id == id).FirstOrDefault();
        }
    }
}
