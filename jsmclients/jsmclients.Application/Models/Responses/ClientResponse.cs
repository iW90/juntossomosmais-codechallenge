using jsmclients.Core.Enums;
using System.Collections.Generic;

namespace jsmclients.Application.Models.Responses
{
    public class ClientResponse
    {
        public ClientTypeEnum Type { get; set; }
        public string Gender { get; set; }
        public NameResponse Name { get; set; }
        public LocationResponse Location { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Registered { get; set; }
        public List<string> TelephoneNumbers { get; set; }
        public List<string> MobileNumbers { get; set; }
        public PicturesResponse Pictures { get; set; }
        public string Nationality { get; set; }
    }
}
