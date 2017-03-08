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
    public class When_Serializing_Coordinate
    {
        [TestCase(-122.39697, 37.78029)]
        [TestCase(-122.19052, 37.362823)]
        public void Then_Coordinate_Should_Be_Serialized_Correctly(decimal longitude, decimal lat)
        {
            string jsonExpected = "[" + longitude + "," + lat + "]";

            Coordinate inputCoor = new Coordinate(longitude, lat);

            string jsonResultActual = JsonConvert.SerializeObject(inputCoor);

            Assert.IsNotNull(jsonResultActual);
            Assert.AreEqual(jsonExpected, jsonResultActual);
        }
    }
}
