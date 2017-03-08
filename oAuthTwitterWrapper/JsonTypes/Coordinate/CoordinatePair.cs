using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinate
{
    public class CoordinatePair : ICoordinatePair
    {
        //TJM: This item can never have children.
        private IEnumerable<ICoordinateCollection> child = null;

        public CoordinatePair()
        {
        }

        public CoordinatePair(decimal latitude, decimal longitude, bool isLegacyFormat)
        {
            Latitude = latitude;
            Longitude = longitude;
            IsLegacyFormat = isLegacyFormat;
        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public IEnumerable<ICoordinateCollection> Children
        {
            get
            {
                return child;
            }
            set
            {
                //TJM: Don't do anything here as we don't actually want this to be set.
            }
        }

        public bool IsLegacyFormat { get; set; }
    }
}
