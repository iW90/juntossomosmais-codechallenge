using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class CoordinatesDTO
    {
        [StringLength(11)]
        public string Latitude { get; set; }

        [StringLength(11)]
        public string Longitude { get; set; }
        public LocationDTO Location { get; set; }
    }
}
