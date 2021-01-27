using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Cars.Dto;
using UITMBER.Api.Repositories.Locations.Dto;

namespace UITMBER.Api.Repositories.Locations
{
    public interface ILocationRepository
    {
        Task<SaveLocationDto> SaveMyLocation(long id, double latitude, double longitude);

    }
}
