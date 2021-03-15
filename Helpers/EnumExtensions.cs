using System;
using Newtonsoft.Json;

namespace Polygon.Data
{
    internal static class EnumExtensions
    {
        private static readonly Char[] _doubleQuotes = { '"' };

        public static String ToEnumString<T>(
            this T enumValue)
            where T : struct, Enum => 
            JsonConvert.SerializeObject(enumValue).Trim(_doubleQuotes);
    }
}
