using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UITMBER.Api.DataModels
{
    public class UserApplication
    {
        public long Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }

        public DateTime Date { get; set; }
        public bool Accepted { get; set; }
        public string DriverLicenceNo { get; set; }
        public string DriverLicencePhoto { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        public long CarId { get; set; }
    }
}
