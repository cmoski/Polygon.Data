using System;

namespace Polygon.Data
{
    internal sealed class LiveEnvironment : IEnvironment
    {
        public Uri PolygonDataApi { get; } = new Uri("https://api.polygon.io");

        public Uri AlpacaStreamingApi { get; } = new Uri("wss://api.alpaca.markets/stream");

        public Uri PolygonStreamingApi { get; } = new Uri("wss://socket.polygon.io/stocks");

        public Uri AlpacaDataStreamingApi { get; } = new Uri("wss://data.alpaca.markets/stream");
    }
}
