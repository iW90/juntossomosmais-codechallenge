using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsmclients.Application.Models.Responses
{
    public class LocationResponse
    {
        public string Region { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
        public CoordinatesResponse Coordinates { get; set; }
        public TimezoneResponse Timezone { get; set; }
    }
}
