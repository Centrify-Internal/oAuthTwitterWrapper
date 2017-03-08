using Newtonsoft.Json;
using OAuthTwitterWrapper.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes
{
    /// <summary>
    /// This class is mainly to support usages of the legacy format for coordinate info. Seems to be needed
    /// </summary>
    [JsonConverter(typeof(LegacyCoordinateJsonConverter))]
    public class LegacyCoordinate : ICoordinate
    {
        public LegacyCoordinate()
        {

        }

        /// <summary>
        /// This format of latitude being first follows the legacy format that Twitter has.
        /// More info here: https://dev.twitter.com/rest/reference/get/statuses/show/id
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public LegacyCoordinate(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
