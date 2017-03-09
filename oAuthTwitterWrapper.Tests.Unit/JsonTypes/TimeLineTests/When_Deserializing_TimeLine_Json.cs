using Newtonsoft.Json;
using NUnit.Framework;
using OAuthTwitterWrapper.Tests.Unit.TestHelpers;
using OAuthTwitterWrapper.JsonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthTwitterWrapper.Tests.Unit.JsonTypes.TimeLineTests
{
    /// <summary>
    /// TJM: This is a special test suite in that I am not exactly testing a method, but I am testing that our datatypes are set up correctly 
    /// to have different samples of JSON to be deserialized correctly.
    /// 
    /// </summary>
    [TestFixture]
    public class When_Deserializing_TimeLine_Json
    {
        [Test]
        public void And_Geo_Property_Is_NonNull_And_Type_Is_Point_Then_Deserialization_Should_Not_Throw_Errors()
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithGeoPropertySet();

            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<List<TimeLine>>(testJson));

        }

        [Test]
        public void And_Geo_Property_Is_NonNull_And_Type_Is_LineString_Then_Deserialization_Should_Not_Throw_Errors()
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithGeoPropertySet("LineString");

            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<List<TimeLine>>(testJson));

        }

        [Test]
        public void And_Geo_Property_Is_NonNull_And_Type_Is_Polygon_Then_Deserialization_Should_Not_Throw_Errors()
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithGeoPropertySet("Polygon");

            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<List<TimeLine>>(testJson));

        }

        [Test]
        public void And_Geo_Property_Is_NonNull_And_An_Unsupported_Coordinate_Type_Then_Deserialization_Should_Not_Throw_Errors()
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithGeoPropertySet("Unknown");

            Assert.DoesNotThrow(() =>
                {
                    List<TimeLine> timelineItem = JsonConvert.DeserializeObject<List<TimeLine>>(testJson);
                });

        }

        public void And_Places_Property_Is_NonNull_Then_Deserialization_Should_Not_Throw_Errors()
        {

        }

        public void And_Coordinates_Property_Is_NonNull_Then_Deserialization_Should_Not_Throw_Errors()
        {

        }
    }
}
