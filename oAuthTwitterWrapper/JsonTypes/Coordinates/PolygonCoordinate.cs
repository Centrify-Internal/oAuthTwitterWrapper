using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    public class PolygonCoordinate : ITypedCoordinate
    {
        public PolygonCoordinate()
        {

        }

        public PolygonCoordinate(ICoordinateCollection coordinates)
        {
            Coordinates = coordinates;
        }

        public ICoordinateCollection Coordinates { get; set; }

        public string Type
        {
            get
            {
                return "Polygon";
            }
        }
    }
}
