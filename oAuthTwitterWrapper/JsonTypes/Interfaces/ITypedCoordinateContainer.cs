using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Interfaces
{
    public interface ITypedCoordinateContainer
    {
        ITypedCoordinate Coordinates { get; set; }
    }
}
