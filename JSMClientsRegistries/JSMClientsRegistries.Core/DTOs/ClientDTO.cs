using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class ClientDTO
    {

        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }

        public NameDTO Name { get; set; }
        public LocationDTO Location { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DobDTO Dob { get; set; }
        public RegisteredDTO Registered { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Cel { get; set; }

        public PicturesDTO Pictures { get; set; }
    }
}
