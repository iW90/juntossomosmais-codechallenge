using System;

namespace JSMClientsRegistries.Core.DTOs
{
    public class RegisteredDTO
    {
        public DateTime Date { get; set; }
        public int Age { get; set; }
        public ClientDTO Client { get; set; }
    }
}
