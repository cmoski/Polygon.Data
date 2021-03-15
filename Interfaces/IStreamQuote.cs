using System;
using System.Diagnostics.CodeAnalysis;

namespace Polygon.Data
{
    /// <summary>
    /// Encapsulates quote information from Polygon streaming API.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IStreamQuote : IQuoteBase<Int64>, IStreamBase
    {
        /// <summary>
        /// Gets quote timestamp in UTC time zone.
        /// </summary>
        DateTime TimeUtc { get; }
    }
}
