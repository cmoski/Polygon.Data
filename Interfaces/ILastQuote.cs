using System;
using System.Diagnostics.CodeAnalysis;

namespace Polygon.Data
{
    /// <summary>
    /// Encapsulates last quote information from Alpaca REST API.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface ILastQuote : IStreamQuote
    {
        /// <summary>
        /// Gets quote response status.
        /// </summary>
        String Status { get; }
    }
}
