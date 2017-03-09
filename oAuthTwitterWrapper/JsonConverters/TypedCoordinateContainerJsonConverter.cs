using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OAuthTwitterWrapper.JsonTypes;
using OAuthTwitterWrapper.JsonTypes.Coordinates;
using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonConverters
{
    /// <summary>
    /// This is meant to be used for deserializing <see cref="ITypedCoordinateContainer"/> types.  I don't yet support serialization, as it is not an important requirement right now.
    /// </summary>
    public class TypedCoordinateContainerJsonConverter : JsonConverter
    {
        private bool _isLegacyFormat = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLegacyFormat">For Twitter "legacy" format, latitude is stored first in JSON array. If legacy format is expected, then set to True so conversion is correct.</param>
        public TypedCoordinateContainerJsonConverter(bool isLegacyFormat)
        {
            _isLegacyFormat = isLegacyFormat;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ITypedCoordinateContainer).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject jsonObj = JObject.Load(reader);

                ITypedCoordinateContainer typedCoorContainerResult = (ITypedCoordinateContainer)Activator.CreateInstance(objectType);
                

                if (jsonObj.HasValues)
                {
                    JProperty typeProp = jsonObj.Property("type");
                    JProperty coordinatesProp = jsonObj.Property("coordinates");
                    if (typeProp != null && coordinatesProp != null)
                    {
                        string type = typeProp.Value.ToString();
                        JArray coorArray = string.IsNullOrWhiteSpace(coordinatesProp.Value.ToString()) ? null : JArray.FromObject(coordinatesProp.Value);
                        if (coorArray != null)
                        {
                            ICoordinateCollection coorResult = null;
                            ITypedCoordinate typedCoorResult = null;

                            if (type == "Point")
                            {
                                //TJM: Assume simple array of coordinate pairs...
                                coorResult = GetPointFromJArray(coorArray, _isLegacyFormat);
                                //TJM: It's ok if the coorResult is null.
                                typedCoorResult = new PointCoordinate(coorResult);
                            }
                            else if (type == "LineString")
                            {
                                //TJM: Assume array of "Point".
                                coorResult = GetLineStringFromJArray(coorArray, _isLegacyFormat);
                                typedCoorResult = new LineStringCoordinate(coorResult);
                            }
                            else if (type == "Polygon")
                            {
                                //TJM: Assume array of "LineString".
                                coorResult = GetPolygonFromJArray(coorArray, _isLegacyFormat);
                                typedCoorResult = new PolygonCoordinate(coorResult);
                            }

                            typedCoorContainerResult.Coordinates = typedCoorResult;

                            return typedCoorContainerResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TJM: Should we do anything here??
            }
            
            return null;
        }

        protected virtual Point GetPointFromJArray(JArray coordinateArray, bool isLegacyFormat)
        {
            if(coordinateArray == null)
            {
                return null;
            }

            SimpleCoordinate coor = GetCoordinateFromJArray(coordinateArray, _isLegacyFormat);
            if (coor != null)
            {
                return new Point(coor.Latitude, coor.Longitude, _isLegacyFormat);
            }

            return null;
        }

        protected virtual LineString GetLineStringFromJArray(JArray coordinateArray, bool isLegacyFormat)
        {
            if (coordinateArray == null)
            {
                return null;
            }

            List<Point> points = new List<Point>();

            for(int i = 0; i < coordinateArray.Count; i++)
            {
                //TJM: Each item in the JArray should be another array.
                Point pointItem = GetPointFromJArray(JArray.FromObject(coordinateArray[i]), isLegacyFormat);
                if(pointItem != null)
                {
                    points.Add(pointItem);
                }
            }

            if(points.Count > 0)
            {
                return new LineString(points);
            }

            return null;
        }

        protected virtual Polygon GetPolygonFromJArray(JArray coordinateArray, bool isLegacyFormat)
        {
            if (coordinateArray == null)
            {
                return null;
            }

            List<LineString> lineStrings = new List<LineString>();

            for (int i = 0; i < coordinateArray.Count; i++)
            {
                //TJM: Each item in the JArray should be another array of arrays.
                LineString lineStringItem = GetLineStringFromJArray(JArray.FromObject(coordinateArray[i]), isLegacyFormat);
                if (lineStringItem != null)
                {
                    lineStrings.Add(lineStringItem);
                }
            }

            if (lineStrings.Count > 0)
            {
                return new Polygon(lineStrings);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            /*
            Coordinate coordinateVal = value as Coordinate;
            writer.WriteStartArray();
            serializer.Serialize(writer, coordinateVal.Longitude);
            serializer.Serialize(writer, coordinateVal.Latitude);
            writer.WriteEndArray();
            */


            throw new NotImplementedException();
        }


        //TJM: Example of traversing that could be applied to serialization...if we ever need to support that
        /*
        public static void RecursiveChildrenTraverse(IEnumerable<ICoordinateCollection> children, int level = 0)
        {

            if (children == null)
            {
                return;
            }

            int loopIndexCount = 0;

            foreach (ICoordinateCollection item in children)
            {
                if (item.Children != null)
                {
                    Console.Write("[");
                    RecursiveChildrenTraverse(item.Children, level + 1);
                    Console.Write("]");

                    if (level > 0 && loopIndexCount < children.Count() - 1)
                    {
                        //TJM: This helps us to put the commas in the right spot (for serialization)...
                        //Console.Write("--level_" + level + "--");
                        Console.Write(",");
                    }

                }
                else
                {
                    //TJM: We assume that if item.Children is null then we are at a CoordinatePair (kind of like the leaf in a tree structure).
                    ICoordinatePair itemCoorPair = item as ICoordinatePair;
                    if (itemCoorPair != null)
                    {
                        //Console.WriteLine("Latitude: " + itemCoorPair.Latitude + ", Longitude: " + itemCoorPair.Longitude);
                        Console.Write(itemCoorPair.Latitude + "," + itemCoorPair.Longitude);
                    }
                }


                if (level == 0)
                {
                    //TJM: This is just for testing...
                    Console.WriteLine();
                }
                else
                {
                    //Console.Write("||");
                }

                loopIndexCount++;
            }
            
        }
        */



        public override bool CanWrite
        {
            get
            {
                //TODO: Change this if we ever have to support serialization for this data.
                return false;
            }
        }

        protected virtual SimpleCoordinate GetCoordinateFromJArray(JArray coorArray, bool isLegacyFormat)
        {
            if(coorArray == null || coorArray.Count < 2)
            {
                return null;
            }

            decimal latitude;
            decimal longitude;

            if(isLegacyFormat)
            {
                //TJM: For Twitter "legacy" format...latitude is stored first in JSON array.
                latitude = (decimal)coorArray[0];
                longitude = (decimal)coorArray[1];
            }
            else
            {
                //TJM: In the "newer", GeoJSON format used...longitude is stored first in JSON array.
                longitude = (decimal)coorArray[0];
                latitude = (decimal)coorArray[1];
            }

            return new SimpleCoordinate(latitude, longitude);
        }


        public class SimpleCoordinate
        {
            public SimpleCoordinate(decimal latitude, decimal longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
        }
    }
}
