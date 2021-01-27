using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.Repositories.Auth;
using UITMBER.Api.ViewModels.Account;
using UITMBER.Api.Extensions;

namespace UITMBER.Api.Controllers
{
    /// <summary>
    /// Author : irinapukish
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly AppSettings _appSettings;

        public ClientsController(IClientRepository clientRepository, AppSettings appSettings)
        {
            _clientRepository = clientRepository;
            _appSettings = appSettings;
        }

        [HttpGet]
        public async Task<ActionResult<ClientProfileDto>> GetMyProfile()
        {
            var userProfileResult = await _clientRepository.GetUserProfile(this.UserId());

            if (!userProfileResult)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Conflict(HttpStatusCode.InternalServerError.ToString());
            }

            return Ok(AccountProfileVM.FromAccountProfileDto(userProfileResult));
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePhoto(string base64Photo)
        {
            var updatePhotoResult = await _clientRepository.UpdateProfilePhoto(this.UserId(), base64Photo);

            if (!updatePhotoResult)
            {
                return Conflict("UploadError");
            }

            return Ok();
        }
    }
}
