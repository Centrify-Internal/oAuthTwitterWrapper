using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes
{
    public interface ICoordinate
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}
