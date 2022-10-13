using Newtonsoft.Json;
using System;

namespace JSMClientsRegistries.Core.DTOs
{
    public class RegisteredDTO
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }


        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
