using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Aplication.Dto;

namespace UITMBER.Api.Repositories.Aplication
{
    public interface IAplicationRepository
    {
        Task<bool> SendApplication(AplicationDto ApDto);
        Task<List<UserApplication>> GetMyApplications(long userId);

    }
}
