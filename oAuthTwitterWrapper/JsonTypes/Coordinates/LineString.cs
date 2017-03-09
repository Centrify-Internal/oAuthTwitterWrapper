using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    /// <summary>
    /// TJM: LineString is made up of a one or more points.
    /// </summary>
    public class LineString : ICoordinateCollection
    {

        public LineString(List<Point> points)
        {
            Children = points;
        }

        public IEnumerable<ICoordinateCollection> Children { get; set; }
    }
}
