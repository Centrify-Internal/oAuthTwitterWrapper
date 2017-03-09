using Newtonsoft.Json;
using OAuthTwitterWrapper.JsonConverters;
using OAuthTwitterWrapper.JsonTypes.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes
{
    public class Place
    {
        [JsonProperty("attributes")]
        public object Attributes { get; set; }

        [JsonProperty("bounding_box")]
        [JsonConverter(typeof(TypedCoordinateContainerJsonConverter), false)]
        public TypedCoordinateContainer BoundingBox { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("place_type")]
        public string PlaceType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }
}
