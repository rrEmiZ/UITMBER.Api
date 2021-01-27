using UITMBER.Api.DataModels;

namespace UITMBER.Api.Repositories.Auth
{
    public class ClientProfileDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public double? ClientRate { get; set; }

        //Check if result is success
        public static implicit operator bool(ClientProfileDto o) => (o != null);

        //Converter db User -> ClientProfileDto
        public static ClientProfileDto FromAccountProfileDto(User m)
        {
            return new ClientProfileDto
            {
                Id = m.Id,
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName,
                PhoneNumber = m.PhoneNumber,
                Photo = m.Photo
            };
        }
    }
}
