using Newtonsoft.Json;
using OAuthTwitterWrapper.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes
{
    [JsonConverter(typeof(CoordinateJsonConverter))]
    public class Coordinate : ICoordinate
    {
        public Coordinate()
        {

        }

        /// <summary>
        /// This format of longitude being first follows the newer format that Twitter will be using similar to GEOJson.
        /// More info here: https://dev.twitter.com/rest/reference/post/statuses/update
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public Coordinate(decimal longitude, decimal latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
