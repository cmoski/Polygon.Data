using System;

namespace Polygon.Data
{
    /// <summary>
    /// Provides URLs for different APIs available for this SDK on specific environment.
    /// </summary>
    public interface IEnvironment
    {    
        /// <summary>
        /// Gets Polygon.io data REST API base URL for this environment.
        /// </summary>
        Uri PolygonDataApi { get; }

        /// <summary>
        /// Gets Polygon.io streaming API base URL for this environment.
        /// </summary>
        Uri PolygonStreamingApi { get; }

    }
}
