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
    public class When_Serializing_LegacyCoordinate_To_Legacy_Format
    {
        [TestCase(37.78029, -122.39697)]
        [TestCase(37.362823, -122.19052)]
        public void Then_Coordinate_Should_Be_Serialized_Correctly(decimal lat, decimal longitude)
        {
            string jsonExpected = "[" + lat + "," + longitude + "]";

            LegacyCoordinate inputCoor = new LegacyCoordinate(lat, longitude);

            //TJM: I need to specify the converter so that it doesn't use the default one.
            string jsonResultActual = JsonConvert.SerializeObject(inputCoor);

            Assert.IsNotNull(jsonResultActual);
            Assert.AreEqual(jsonExpected, jsonResultActual);
        }
    }
}
