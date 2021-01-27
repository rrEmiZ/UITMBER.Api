using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Aplication;
using UITMBER.Api.Repositories.Aplication.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AplicationController : Controller
    {


        private readonly IAplicationRepository _AplicationRepository;
       
        private readonly AppSettings _appSettings;

        public AplicationController(IAplicationRepository AplicationRepository, AppSettings appSettings)
        {
            _AplicationRepository = AplicationRepository;
            _appSettings = appSettings;
        }
        [HttpPost]
        public async Task<IActionResult> SendApplication([FromBody] AplicationDto ApDto)
        {
            try
            {
                var result = await _AplicationRepository.SendApplication(ApDto);
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
        [HttpGet("{userId}")]
        public async Task<List<UserApplication>> GetMyApplications(long userId)
        {
            try
            {
                var result = await _AplicationRepository.GetMyApplications(userId);

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
