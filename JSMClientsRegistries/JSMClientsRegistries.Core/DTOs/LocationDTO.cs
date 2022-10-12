using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class LocationDTO
    {
        [StringLength(255)]
        public string Street { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public int Postcode { get; set; }


        public CoordinatesDTO Coordinates { get; set; }
        public TimezoneDTO Timezone { get; set; }
        public ClientDTO Client { get; set; }
    }
}
