using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    public class LineStringCoordinate : ITypedCoordinate
    {
        public LineStringCoordinate()
        {

        }

        public LineStringCoordinate(ICoordinateCollection coordinates)
        {
            Coordinates = coordinates;
        }

        public ICoordinateCollection Coordinates { get; set; }

        public string Type
        {
            get
            {
                return "LineString";
            }
        }
    }
}
