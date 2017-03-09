using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Interfaces
{
    public interface ICoordinatePair : ICoordinateCollection
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }

        bool IsLegacyFormat { get; set; }
    }
}
