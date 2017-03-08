using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OAuthTwitterWrapper.JsonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonConverters
{
    /// <summary>
    /// TJM: This is to support the new format for coordinates of longitude first and latitude second as described here: https://dev.twitter.com/rest/reference/post/statuses/update
    /// </summary>
    public class CoordinateJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //TJM: We only handle an array of ints here...
            return objectType.IsArray && objectType.GetElementType() == typeof(decimal);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JArray jsonArray = JArray.Load(reader);
                if (jsonArray.HasValues && jsonArray.Count >= 2)
                {
                    return new Coordinate
                    {
                        Longitude = (decimal)jsonArray[0],
                        Latitude = (decimal)jsonArray[1]
                    };
                }
            }
            catch (Exception ex)
            {
                //TJM: Should we do anything here??
            }
            
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Coordinate coordinateVal = value as Coordinate;
            writer.WriteStartArray();
            serializer.Serialize(writer, coordinateVal.Longitude);
            serializer.Serialize(writer, coordinateVal.Latitude);
            writer.WriteEndArray();
        }
    }
}
