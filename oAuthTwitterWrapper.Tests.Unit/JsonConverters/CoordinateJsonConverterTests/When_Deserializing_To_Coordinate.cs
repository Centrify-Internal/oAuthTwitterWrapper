using Newtonsoft.Json;
using NUnit.Framework;
using OAuthTwitterWrapper.JsonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oAuthTwitterWrapper.Tests.Unit.JsonConverters.CoordinateJsonConverterTests
{
    [TestFixture]
    public class When_Deserializing_To_Coordinate
    {
        [TestCase(-122.39697, 37.78029)]
        [TestCase(-122.19052, 37.362823)]
        public void Then_Array_Of_Two_Decimals_Should_Be_Deserialized_Correctly(decimal longitude, decimal lat)
        {
            string jsonTest = "[" + longitude + "," + lat + "]";

            Coordinate resultCoor = JsonConvert.DeserializeObject<Coordinate>(jsonTest);

            Assert.IsNotNull(resultCoor);
            Assert.AreEqual(longitude, resultCoor.Longitude);
            Assert.AreEqual(lat, resultCoor.Latitude);
        }
    }
}
