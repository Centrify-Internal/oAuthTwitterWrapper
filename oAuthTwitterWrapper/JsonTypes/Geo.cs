using Newtonsoft.Json;
using OAuthTwitterWrapper.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes
{
    public class Geo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public LegacyCoordinate Coordinates { get; set; }
    }
}
