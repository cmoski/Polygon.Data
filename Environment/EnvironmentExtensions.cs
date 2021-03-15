using System;
using System.Diagnostics.CodeAnalysis;

namespace Polygon.Data
{
    /// <summary>
    /// Collection of helper extension methods for <see cref="IEnvironment"/> interface.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class EnvironmentExtensions
    {

        /// <summary>
        /// Creates the new instance of <see cref="IPolygonDataClient"/> interface
        /// implementation for specific environment provided as <paramref name="environment"/> argument.
        /// </summary>
        /// <param name="environment">Target environment for new object.</param>
        /// <param name="keyId">Alpaca API key identifier.</param>
        /// <returns>The new instance of <see cref="IPolygonDataClient"/> interface implementation.</returns>
        public static IPolygonDataClient GetPolygonDataClient(
            this IEnvironment environment,
            String keyId) =>
            new PolygonDataClient(environment.GetPolygonDataClientConfiguration(keyId));

        /// <summary>
        /// Creates new instance of <see cref="PolygonDataClientConfiguration"/> for specific
        /// environment provided as <paramref name="environment"/> argument.
        /// </summary>
        /// <param name="environment">Target environment for new object.</param>
        /// <param name="keyId">Alpaca API key identifier.</param>
        /// <returns>New instance of <see cref="PolygonDataClientConfiguration"/> object.</returns>
        public static PolygonDataClientConfiguration GetPolygonDataClientConfiguration(
            this IEnvironment environment,
            String keyId) =>
            new PolygonDataClientConfiguration
            {
                ApiEndpoint = environment.EnsureNotNull(nameof(environment))
                    .PolygonDataApi.EnsureNotNull(nameof(IEnvironment.PolygonDataApi)),
                KeyId = keyId ?? throw new ArgumentNullException(nameof(keyId))
            };


        /// <summary>
        /// Creates the new instance of <see cref="IPolygonStreamingClient"/> interface
        /// implementation for specific environment provided as <paramref name="environment"/> argument.
        /// </summary>
        /// <param name="environment">Target environment for new object.</param>
        /// <param name="keyId">Alpaca API key identifier.</param>
        /// <returns>The new instance of <see cref="IPolygonStreamingClient"/> interface implementation.</returns>
        public static IPolygonStreamingClient GetPolygonStreamingClient(
            this IEnvironment environment,
            String keyId) =>
            new PolygonStreamingClient(environment.GetPolygonStreamingClientConfiguration(keyId));

        /// <summary>
        /// Creates new instance of <see cref="PolygonStreamingClientConfiguration"/> for specific
        /// environment provided as <paramref name="environment"/> argument.
        /// </summary>
        /// <param name="environment">Target environment for new object.</param>
        /// <param name="keyId">Alpaca API key identifier.</param>
        /// <returns>New instance of <see cref="PolygonStreamingClientConfiguration"/> object.</returns>
        public static PolygonStreamingClientConfiguration GetPolygonStreamingClientConfiguration(
            this IEnvironment environment,
            String keyId) =>
            new PolygonStreamingClientConfiguration()
            {
                ApiEndpoint = environment.EnsureNotNull(nameof(environment))
                    .PolygonStreamingApi.EnsureNotNull(nameof(IEnvironment.PolygonStreamingApi)),
                KeyId = keyId.EnsureNotNull(nameof(keyId))
            };
    }
}
