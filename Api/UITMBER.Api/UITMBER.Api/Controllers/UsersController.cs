using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Users;
using UITMBER.Api.Repositories.Users.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
   // [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : Controller
    {
        private IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<UserDto>> GetList()
        {
            return _repository.GetList();
        }

        [HttpPut]
        public Task<bool> SetAsDriver(long newDriverId)
        {
            return _repository.SetAsDriver(newDriverId);
        }


        [HttpGet]
        public Task<List<UserApplication>> GetAllApplications()
        {
            return _repository.GetAllApplications();
        }

        [HttpPut]
        public async Task<bool> SetAccepted(long appId)
        {
           await _repository.SetAccepted(appId);
            return true;
        }

    }
}
