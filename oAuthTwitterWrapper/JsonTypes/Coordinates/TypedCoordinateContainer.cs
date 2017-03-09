using Newtonsoft.Json;
using OAuthTwitterWrapper.JsonConverters;
using OAuthTwitterWrapper.JsonTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterWrapper.JsonTypes.Coordinates
{
    /// <summary>
    /// TJM: Note that there is no JSON converter attribute attached to this directly since certain usages of this type might have different settings for converter and it seems if one 
    /// is set on the class, it takes precedence.
    /// </summary>
    public class TypedCoordinateContainer : ITypedCoordinateContainer
    {
        public ITypedCoordinate Coordinates { get; set; }
    }
}
