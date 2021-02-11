using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Locations;

namespace UITMBER.Api.Controllers
{
    /// <summary>
    /// Author : LipaMar
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyLocation(double latitude, double longitude)
        {

            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            try
            {

                var saveLocationResult = await _locationRepository.SaveMyLocation(userId, latitude, longitude);

                if (!saveLocationResult.Success)
                {
                    return BadRequest(saveLocationResult.Error = "Error");
                }
                return Ok(saveLocationResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
