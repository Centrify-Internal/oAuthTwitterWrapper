using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinate
{
    /// <summary>
    /// TJM: Polygon is made up of one or more linestrings (not officially), but that's how I will assemble it.
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
