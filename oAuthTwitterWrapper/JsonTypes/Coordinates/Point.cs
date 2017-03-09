using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    /// <summary>
    /// TJM: Point is made up of a single coordinate pair.
    /// </summary>
    public class Point : ICoordinateCollection
    {

        public Point(decimal latitude, decimal longitude, bool isLegacyFormat)
        {
            Children = new List<ICoordinateCollection>
                        {
                            new CoordinatePair(latitude, longitude, isLegacyFormat)
                        };
        }

        public IEnumerable<ICoordinateCollection> Children { get; set; }
    }
}
