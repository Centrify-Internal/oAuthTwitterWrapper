using Newtonsoft.Json;
using NUnit.Framework;
using OAuthTwitterWrapper.JsonConverters;
using OAuthTwitterWrapper.JsonTypes.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oAuthTwitterWrapper.Tests.Unit.JsonConverters.TypedCoordinateContainerJsonConverterTests
{
    [TestFixture]
    public class When_Deserializing_TypedCoordinateContainer_Json
    {
        /// <summary>
        /// TJM: Note that "GeometryCollection" is not yet supported since it has an even more complex/different structure so I am testing it here to make sure 
        /// if we EVER get one, it at least won't cause an error (it should take the same path as the unsupported "Unknown" type).
        /// </summary>
        /// <param name="inputJson"></param>
        [TestCase("{ \"type\":\"Unknown\", \"coordinates\":null }", "Unknown")]
        [TestCase("{ \"type\":\"Point\", \"coordinates\":[37.78029, -122.39697] }", "Point")]
        [TestCase("{ \"type\":\"LineString\", \"coordinates\":[[37.78029, -122.39697],[38.78029, -121.39697]] }", "LineString")]
        [TestCase("{ \"type\":\"Polygon\", \"coordinates\":[[[37.78029, -122.39697],[38.78029, -121.39697],[39.78029, -120.39697]],[[36.78029, -122.39697],[34.78029, -121.39697],[35.78029, -120.39697]]] }"
            , "Polygon")]
        [TestCase("{\"type\":\"GeometryCollection\",\"geometries\":[{\"type\":\"Point\",\"coordinates\":[100,0]},{\"type\":\"LineString\",\"coordinates\":[[101,0],[102,1]]}]}", "GeometryCollection")]
        public void And_Geo_Object_Is_Being_Deserialized_Then_TypedCoordinateContainer_Object_Is_Correctly_Created(string inputJson, string coordinateType)
        {
            TypedCoordinateContainer result = JsonConvert.DeserializeObject<TypedCoordinateContainer>(inputJson, new JsonConverter[] { new TypedCoordinateContainerJsonConverter(true) });

            switch (coordinateType)
            {
                case "Unknown":
                    AssertsForUnknown(result);
                    return;
                case "Point":
                    AssertsForPoint(result);
                    return;
                case "LineString":
                    AssertsForLineString(result);
                    return;
                case "Polygon":
                    AssertsForPolygon(result);
                    return;
                case "GeometryCollection":
                    AssertsForGeometryCollection(result);
                    return;
                default:
                    Assert.Fail();
                    break;
            }
        }


        protected void AssertsForUnknown(TypedCoordinateContainer result)
        {
            Assert.IsNull(result);
        }


        protected void AssertsForPoint(TypedCoordinateContainer result)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Coordinates);
            Assert.IsTrue(result.Coordinates.GetType().Name == "PointCoordinate");
        }

        protected void AssertsForLineString(TypedCoordinateContainer result)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Coordinates);
            Assert.IsTrue(result.Coordinates.GetType().Name == "LineStringCoordinate");
        }

        protected void AssertsForPolygon(TypedCoordinateContainer result)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Coordinates);
            Assert.IsTrue(result.Coordinates.GetType().Name == "PolygonCoordinate");
        }

        protected void AssertsForGeometryCollection(TypedCoordinateContainer result)
        {
            Assert.IsNull(result);
        }
    }
}
