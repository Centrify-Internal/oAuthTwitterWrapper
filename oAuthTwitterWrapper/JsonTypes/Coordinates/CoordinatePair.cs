using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    public class CoordinatePair : ICoordinatePair
    {
        //TJM: This item can never have children.
        private IEnumerable<ICoordinateCollection> child = null;

        public CoordinatePair()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="isLegacyFormat">For Twitter "legacy" format, latitude is stored first in JSON array, so this is mainly for indicating legacy format for conversion to/from JSON.</param>
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

        /// <summary>
        /// For Twitter "legacy" format, latitude is stored first in JSON array, so this is mainly for indicating legacy format for conversion to/from JSON.
        /// </summary>
        public bool IsLegacyFormat { get; set; }
    }
}
