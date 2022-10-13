using System.Text.Json.Serialization;

namespace JSMClientsRegistries.Core.DTOs
{
    public class ClientDTO
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }


        [JsonPropertyName("name")]
        public NameDTO Name { get; set; }


        [JsonPropertyName("location")]
        public LocationDTO Location { get; set; }


        [JsonPropertyName("email")]
        public string Email { get; set; }


        [JsonPropertyName("dob")]
        public DobDTO Dob { get; set; }


        [JsonPropertyName("registered")]
        public RegisteredDTO Registered { get; set; }


        [JsonPropertyName("phone")]
        public string Phone { get; set; }


        [JsonPropertyName("cell")]
        public string Cell { get; set; }


        [JsonPropertyName("picture")]
        public PictureDTO Picture { get; set; }
    }
}
