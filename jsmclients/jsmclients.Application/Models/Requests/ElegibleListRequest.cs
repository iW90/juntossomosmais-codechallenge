﻿using jsmclients.Core.Enums;

namespace jsmclients.Application.Models.Requests
{
    public class ElegibleListRequest
    {
        public ClientTypeEnum Type { get; set; }
        public ClientRegionEnum Region { get; set; }
    }
}
