using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.Repositories.Locations.Dto
{
    public class SaveLocationDto
    {
        public bool Success { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Error { get; set; }
    }
}
