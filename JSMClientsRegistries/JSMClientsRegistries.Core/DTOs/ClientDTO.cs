using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSMClientsRegistries.Core.DTOs
{
    public class ClientDTO
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }


        [JsonProperty("name")]
        public NameDTO Name { get; set; }


        [JsonProperty("location")]
        public LocationDTO Location { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("dob")]
        public DobDTO Dob { get; set; }


        [JsonProperty("registered")]
        public RegisteredDTO Registered { get; set; }


        [JsonProperty("phone")]
        public string Phone { get; set; }


        [JsonProperty("cell")]
        public string Cell { get; set; }


        [JsonProperty("pictures")]
        public PicturesDTO Pictures { get; set; }
    }
}
