using Newtonsoft.Json;
using NUnit.Framework;
using OAuthTwitterWrapper.Tests.Unit.TestHelpers;
using OAuthTwitterWrapper.JsonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuthTwitterWrapper.JsonTypes.Coordinates;
using OAuthTwitterWrapper.JsonTypes.Interfaces;

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
        [TestCase("Unknown")]
        [TestCase("Point")]
        [TestCase("LineString")]
        [TestCase("Polygon")]
        public void And_Geo_Property_Is_NonNull_Then_Deserialization_Should_Not_Throw_Errors(string coordinateType)
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithGeoPropertySet(coordinateType);

            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<List<TimeLine>>(testJson));

        }

        [Test]
        public void And_Geo_Property_Is_NonNull_Then_Coordinates_Should_Be_In_Legacy_Format()
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithGeoPropertySet();

            List<TimeLine> timeline = JsonConvert.DeserializeObject<List<TimeLine>>(testJson);
            TimeLine timelineItem = timeline.FirstOrDefault();

            AssertCoordinateFormatForTypedCoordinateContainer(timelineItem.Geo);
        }


        [TestCase("Unknown")]
        [TestCase("Point")]
        [TestCase("LineString")]
        [TestCase("Polygon")]
        public void And_Place_Property_Is_NonNull_Then_Deserialization_Should_Not_Throw_Errors(string coordinateType)
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithPlacePropertySet(coordinateType);

            Assert.DoesNotThrow(() =>
            {
                List<TimeLine> test = JsonConvert.DeserializeObject<List<TimeLine>>(testJson);
            });
        }


        [TestCase("Unknown")]
        [TestCase("Point")]
        [TestCase("LineString")]
        [TestCase("Polygon")]
        public void And_Coordinates_Property_Is_NonNull_Then_Deserialization_Should_Not_Throw_Errors(string coordinateType)
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithCoordinatesPropertySet(coordinateType);

            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject<List<TimeLine>>(testJson));
        }

        [Test]
        public void And_Coordinates_Property_Is_NonNull_Then_Coordinates_Should_Be_In_New_Format()
        {
            string testJson = DummyTimeLineJson.GetTimeLineJsonWithCoordinatesPropertySet();

            List<TimeLine> timeline = JsonConvert.DeserializeObject<List<TimeLine>>(testJson);

            AssertCoordinateFormatForTypedCoordinateContainer(timeline.FirstOrDefault().Coordinates);
        }


        private void AssertCoordinateFormatForTypedCoordinateContainer(TypedCoordinateContainer coordContainer)
        {
            
            //TJM: The result should be dealing with a Point type for simplicity to check the coordinates.
            ICoordinateCollection coordColl = coordContainer.Coordinates.Coordinates;

            while (coordColl.Children != null)
            {
                coordColl = coordColl.Children.FirstOrDefault();
            }

            CoordinatePair coordPair = coordColl as CoordinatePair;

            string expectedResult = DummyTimeLineJson.GetCoordinateTestValueFromType("Point", coordPair.IsLegacyFormat);
            //TJM: Kind of a hack, but whatever...I want to get the exact result from our sample data.
            expectedResult = expectedResult.Replace("[", "").Replace("]", "");
            string[] coordinateSplit = expectedResult.Split(',');
            // Set values based on whether we're using legacy format for the coordinate.
            decimal latitude = 0;
            decimal longitude = 0;
            for (int i = 0; i < coordinateSplit.Length; i++)
            {
                decimal coordNum;
                if (decimal.TryParse(coordinateSplit[i], out coordNum))
                {
                    if (i == 0)
                    {
                        if (coordPair.IsLegacyFormat)
                        {
                            latitude = coordNum;
                        }
                        else
                        {
                            longitude = coordNum;
                        }
                    }
                    else if (i == 1)
                    {
                        if (coordPair.IsLegacyFormat)
                        {
                            longitude = coordNum;
                        }
                        else
                        {
                            latitude = coordNum;
                        }
                    }
                }
            }

            AssertLatitudeandLongitude(latitude, longitude, coordPair);
        }

        private void AssertLatitudeandLongitude(decimal latitude, decimal longitude, CoordinatePair coordPair)
        {
            Assert.AreEqual(latitude, coordPair.Latitude);
            Assert.AreEqual(longitude, coordPair.Longitude);
        }
    }
}
