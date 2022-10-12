using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class PicturesDTO
    {

        [StringLength(255)]
        public string Large { get; set; }

        [StringLength(255)]
        public string Medium { get; set; }

        [StringLength(255)]
        public string Thumbnail { get; set; }

        public ClientDTO Client { get; set; }
    }
}
