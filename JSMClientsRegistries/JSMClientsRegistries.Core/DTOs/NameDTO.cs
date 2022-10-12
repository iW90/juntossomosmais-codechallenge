using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class NameDTO
    {
        [StringLength(10)]
        public string Title { get; set; }


        [StringLength(50)]
        public string First { get; set; }


        [StringLength(50)]
        public string Last { get; set; }
    }
}
