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
        public IActionResult SaveMyLocation(long id, double lat, double longitude)
        {
            if (!areCoordinatesCorrect(lat, longitude))
            {
                return BadRequest("Given coordiantes are incorrect");
            }
            bool modified = _locationRepository.SaveLocation(id, lat, longitude);
            if (modified) return Ok();
            return NotFound("User not found");
        }

        private bool areCoordinatesCorrect(double lat, double longitude)
        {
            return lat >= -90 && lat <= 90 && longitude >= -180 && longitude <= 180;
        }

    }
}
