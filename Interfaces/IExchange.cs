using System;
using System.Diagnostics.CodeAnalysis;

namespace Polygon.Data
{
    /// <summary>
    /// Encapsulates exchange information from Ploygon REST API.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IExchange
    {
        /// <summary>
        /// Gets exchange unique identifier.
        /// </summary>
        Int64 ExchangeId { get; }

        /// <summary>
        /// Gets exchange type.
        /// </summary>
        ExchangeType ExchangeType { get; }

        /// <summary>
        /// Gets market data type.
        /// </summary>
        MarketDataType MarketDataType { get; }

        /// <summary>
        /// Gets exchange market identification code.
        /// </summary>
        String? MarketIdentificationCode { get; }

        /// <summary>
        /// Gets exchange name.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Gets exchange tape ID.
        /// </summary>
        String? TapeId { get; }
    }
}
