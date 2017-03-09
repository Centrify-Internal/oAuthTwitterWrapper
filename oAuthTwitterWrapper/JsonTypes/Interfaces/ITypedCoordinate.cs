using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Interfaces
{
    public interface ITypedCoordinate
    {
        string Type { get; }
        ICoordinateCollection Coordinates { get; set; }
    }
}
