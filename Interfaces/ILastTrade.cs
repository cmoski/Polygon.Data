using System;
using System.Diagnostics.CodeAnalysis;

namespace Polygon.Data
{
    /// <summary>
    /// Encapsulates last trade information from Polygon REST API.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface ILastTrade
    {
        /// <summary>
        /// Gets request status.
        /// </summary>
        String Status { get; }

        /// <summary>
        /// Gets asset name.
        /// </summary>
        String Symbol { get; }

        /// <summary>
        /// Gets asset's exchange identifier.
        /// </summary>
        Int64 Exchange { get; }

        /// <summary>
        /// Gets trade price level.
        /// </summary>
        Decimal Price { get; }

        /// <summary>
        /// Gets trade quantity.
        /// </summary>
        Int64 Size { get; }

        /// <summary>
        /// Gets trade timestamp.
        /// </summary>
        DateTime TimeUtc { get; }
    }
}
