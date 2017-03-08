using Newtonsoft.Json;
using NUnit.Framework;
using OAuthTwitterWrapper.JsonConverters;
using OAuthTwitterWrapper.JsonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oAuthTwitterWrapper.Tests.Unit.JsonConverters.LegacyCoordinateJsonConverterTests
{
    [TestFixture]
    public class When_Deserializing_To_LegacyCoordinate_From_Legacy_Format
    {
        [TestCase(37.78029, -122.39697)]
        [TestCase(37.362823, -122.19052)]
        public void Then_Array_Of_Two_Decimals_Should_Be_Deserialized_Correctly(decimal lat, decimal longitude)
        {
            string jsonTest = "[" + lat + "," + longitude + "]";

            //TJM: I need to specify the converter so that it doesn't use the default one.
            LegacyCoordinate resultCoor = JsonConvert.DeserializeObject<LegacyCoordinate>(jsonTest);

            Assert.IsNotNull(resultCoor);
            Assert.AreEqual(lat, resultCoor.Latitude);
            Assert.AreEqual(longitude, resultCoor.Longitude);
        }
    }
}
