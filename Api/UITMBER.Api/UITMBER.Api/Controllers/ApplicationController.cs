using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.DataModels;
using UITMBER.Api.Extensions;
using UITMBER.Api.Repositories.Aplication;
using UITMBER.Api.Repositories.Aplication.Dto;

namespace UITMBER.Api.Controllers
{
    /// <summary>
    /// Author : w60083
    /// Changes : jjonca
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApplicationController : Controller
    {
        private readonly IAplicationRepository _AplicationRepository;
       
        private readonly AppSettings _appSettings;

        public ApplicationController(IAplicationRepository AplicationRepository, AppSettings appSettings)
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

        [HttpGet()]
        public async Task<List<UserApplication>> GetMyApplications()
        {
            try
            {

                var result = await _AplicationRepository.GetMyApplications(this.UserId());

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
