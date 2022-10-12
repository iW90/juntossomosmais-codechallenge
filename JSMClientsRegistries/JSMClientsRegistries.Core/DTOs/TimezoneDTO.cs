using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class TimezoneDTO
    {
        [StringLength(6)]
        public string Offset { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public LocationDTO Location { get; set; }
    }
}
