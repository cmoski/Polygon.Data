using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Polygon.Data
{
    /// <summary>
    /// Encapsulates news information from Alpaca REST API.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface INewsItem
    {
        /// <summary>
        /// 
        /// </summary>
        string? Title { get; }

        /// <summary>
        /// 
        /// </summary>
        Uri? Url { get; }

        /// <summary>
        /// 
        /// </summary>
        string? Source { get; }

        /// <summary>
        /// 
        /// </summary>
        string? Summary { get; }
        /// <summary>
        /// 
        /// </summary>
        Uri? Image { get; }
        /// <summary>
        /// 
        /// </summary>
        DateTime? TimeStamp { get; }
        /// <summary>
        /// 
        /// </summary>
        Collection<string>? Keywords { get; }
    }
}
