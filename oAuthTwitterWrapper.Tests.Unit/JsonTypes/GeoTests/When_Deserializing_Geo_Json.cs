using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oAuthTwitterWrapper.Tests.Unit.JsonTypes.GeoTests
{
    public class When_Deserializing_Geo_Json
    {
        [TestCase("\"geo\":{ \"type\":\"Point\", \"coordinates\":[37.78029, -122.39697] }")]
        public void Then_Geo_Object_Is_Successfully_Created(string inputJson)
        {

        }
    }
}
