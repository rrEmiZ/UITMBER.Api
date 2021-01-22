
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Configuration;
using UITMBER.Api.Models.Authentication;
using UITMBER.Api.Repositories.Auth;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, AppSettings appSettings)
        {
            _authenticationRepository = authenticationRepository;
            _appSettings = appSettings;
        }

        //Rejestracja
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel input)
        {
            try
            {

                var registerResult = await _authenticationRepository.RegisterAsync(input.Email, input.Password, input.FirstName, input.LastName,
                     input.PhoneNumber, input.Photo);

                if (!registerResult.Success)
                {
                    return BadRequest(registerResult.Error);
                }

                var accessToken = _authenticationRepository.GenerateToken(registerResult, _appSettings);

                return Ok(new AuthenticationReponse()
                {
                    AccessToken = accessToken,
                    ExpireInSeconds = (int)TimeSpan.FromHours(2).TotalSeconds,
                    Name = registerResult.Name,
                    Photo = registerResult.Photo,
                    Roles = registerResult.Roles
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        //Logowanie
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationnModel input)
        {
            try
            {

                var loginResult = await _authenticationRepository.AuthenticateAsync(input.Login, input.Password);

                if (!loginResult.Success)
                {
                    return Unauthorized(loginResult.Error);
                }

                var accessToken = _authenticationRepository.GenerateToken(loginResult, _appSettings);

                return Ok(new AuthenticationReponse()
                {
                    AccessToken = accessToken,
                    ExpireInSeconds = (int)TimeSpan.FromHours(2).TotalSeconds,
                    Name = loginResult.Name,
                    Photo = loginResult.Photo,
                    Roles = loginResult.Roles
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
