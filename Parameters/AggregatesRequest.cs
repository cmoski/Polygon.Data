﻿using System;
using System.Collections.Generic;

namespace Polygon.Data
{
    /// <summary>
    /// Encapsulates request parameters for <see cref="PolygonDataClient.ListAggregatesAsync(AggregatesRequest,System.Threading.CancellationToken)"/> call.
    /// </summary>
    public sealed class AggregatesRequest : Validation.IRequest, IRequestWithTimeInterval<IInclusiveTimeInterval>
    {
        /// <summary>
        /// Creates new instance of <see cref="AggregatesRequest"/> object.
        /// </summary>
        /// <param name="symbol">Asset name for data retrieval.</param>
        /// <param name="period">Aggregation time span (number or bars and base bar size).</param>
        public AggregatesRequest(
            String symbol,
            AggregationPeriod period)
        {
            Symbol = symbol ?? throw new ArgumentException(
                "Symbol name cannot be null.", nameof(symbol));
            Period = period;
        }

        /// <summary>
        /// Gets asset name for data retrieval.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Gets aggregation time span (number or bars and base bar size).
        /// </summary>
        public AggregationPeriod Period { get; }

        /// <summary>
        /// Gets inclusive date interval for filtering items in response.
        /// </summary>
        public IInclusiveTimeInterval TimeInterval { get; set; } = Polygon.Data.TimeInterval.InclusiveEmpty;

        /// <summary>
        /// Gets or sets flag indicated that the results should not be adjusted for splits.
        /// </summary>
        public Boolean? Unadjusted { get; set; }
        
        /// <summary>
        /// Gets or sets the sorting direction for items in response (the ascending if omitted).
        /// </summary>
        public SortDirection? Sort { get; set; }

        /// <summary>
        /// Gets or sets the number of base aggregates queried to create the aggregate results.
        /// </summary>
        public Int32? Limit { get; set; }

        internal UriBuilder GetUriBuilder(
            PolygonDataClient polygonDataClient)
        {
            var unixFrom = (TimeInterval.From ?? default).IntoUnixTimeMilliseconds();
            var unixInto = (TimeInterval.Into ?? default).IntoUnixTimeMilliseconds();

            var builder = polygonDataClient.GetUriBuilder(
                $"v2/aggs/ticker/{Symbol}/range/{Period}/{unixFrom}/{unixInto}");

            builder.QueryBuilder
                .AddParameter("unadjusted", Unadjusted)
                .AddParameter("limit", Limit)
                .AddParameter("sort", Sort);

            return builder;
        }

        IEnumerable<RequestValidationException> Validation.IRequest.GetExceptions()
        {
            if (String.IsNullOrEmpty(Symbol))
            {
                yield return new RequestValidationException(
                    "Symbols shouldn't be empty.", nameof(Symbol));
            }

            if (TimeInterval.IsEmpty())
            {
                yield return new RequestValidationException(
                    "Time interval should be specified.", nameof(TimeInterval));
            }

            if (TimeInterval.IsOpen())
            {
                yield return new RequestValidationException(
                    "Time interval should have both dates.", nameof(TimeInterval));
            }

            if (TimeInterval.IsOpen())
            {
                yield return new RequestValidationException(
                    "Time interval should have both dates.", nameof(TimeInterval));
            }

            if (Limit > 50_000)
            {
                yield return new RequestValidationException(
                    "Maximal aggregation interval value is 50000.", nameof(Limit));
            }
        }

        void IRequestWithTimeInterval<IInclusiveTimeInterval>.SetInterval(
            IInclusiveTimeInterval value) => TimeInterval = value;
    }
}
