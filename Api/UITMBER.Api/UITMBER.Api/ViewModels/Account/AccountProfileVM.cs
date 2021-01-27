using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Auth;

namespace UITMBER.Api.ViewModels.Account
{
    public class AccountProfileVM
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public double? ClientRate { get; set; }

        //Converter ClientProfileDto -> AccountProfileVM
        public static AccountProfileVM FromAccountProfileDto(ClientProfileDto m)
        {
            return new AccountProfileVM
            {
                Id = m.Id,
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName,
                PhoneNumber = m.PhoneNumber,
                Photo = m.Photo,
                ClientRate = m.ClientRate
            };
        }
    }
}
