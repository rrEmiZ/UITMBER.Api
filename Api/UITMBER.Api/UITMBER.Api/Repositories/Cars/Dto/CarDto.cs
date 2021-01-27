using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Enums;

namespace UITMBER.Api.Repositories.Cars.Dto
{
    public class CarDto
    {
        public long Id { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }


        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string PlateNo { get; set; }
        public string Photo { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public CarType Type { get; set; }

        public bool IsActive { get; set; }



    }
}
