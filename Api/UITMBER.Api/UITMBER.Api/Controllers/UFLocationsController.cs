using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Favourites;
using UITMBER.Api.Repositories.Favourites.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UFLocationsController : ControllerBase
    {
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly AppSettings _appSettings;

        public UFLocationsController(IFavouritesRepository favouritesRepository, AppSettings appSettings)
        {
            _favouritesRepository = favouritesRepository;
            _appSettings = appSettings;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto location)
        {
            try
            {
                var result = await _favouritesRepository.AddLocationAsync(location);
                if (result)
                {
                    return Ok("success");
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(long id)
        {
            try
            {
                var result = await _favouritesRepository.DeleteLocationAsync(id);

                if (result)
                {
                    return Accepted();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }

        [HttpGet("{userId}")]
        public async Task<List<UserFavouriteLocation>> GetMyLocations(long userId)
        {
            try
            {
                var result = await _favouritesRepository.GetMyLocationsAsync(userId);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Cannot find data!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
