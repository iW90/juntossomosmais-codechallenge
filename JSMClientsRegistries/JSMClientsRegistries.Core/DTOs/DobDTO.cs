using System;

namespace JSMClientsRegistries.Core.DTOs
{
    public class DobDTO
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public ClientDTO Client { get; set; }
    }
}
