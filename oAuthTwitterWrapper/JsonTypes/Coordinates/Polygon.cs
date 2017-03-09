using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    /// <summary>
    /// TJM: Polygon is made up of one or more <see cref="LineString"/> (not officially), but that's how I will assemble it since I don't have any limitation on how many points a LineString can have.
    /// </summary>
    public class Polygon : ICoordinateCollection
    {

        public Polygon(List<LineString> lineStrings)
        {
            Children = lineStrings;
        }

        public IEnumerable<ICoordinateCollection> Children { get; set; }
    }
}
