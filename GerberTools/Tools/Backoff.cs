using System;
using System.Collections.Generic;

namespace GerberTools.Tools
{
    public static class Backoff
    {
        /// <summary>
        /// Backoff generator for Polly usage. Generates this plot: https://www.desmos.com/calculator/jrshfwvi62.
        /// All parameters must be bigger than 0, except for the offset.
        /// </summary>
        /// <param name="count">Number off Backoff points.</param>
        /// <param name="plateau">Limit time period of the plateau.</param>
        /// <param name="offset">Offset time for the whole series</param>
        /// <param name="plateauSpeed">How fast does the Backoff reach the plateau value. Between >0 and 1 is slow, 1 to 3 is closer to log and >3 is fast.</param>
        /// <returns>Enumerable of TimeSpan.</returns>
        public static IEnumerable<TimeSpan> Create(double count = 3, double plateau = 5, double offset = 1, double plateauSpeed = 1)
        {
            var backoffs = new List<TimeSpan>();

            if (count <= 0 || offset < 0 || plateauSpeed <= 0 || plateau <= 0)
                return backoffs;

            for (var i = 0; i < count; i++)
            {
                var backoff = Math.Pow(i, plateauSpeed) / (1 + (Math.Pow(i, plateauSpeed) / plateau)) + offset;

                backoffs.Add(TimeSpan.FromSeconds(backoff));                
            }

            return backoffs;
        }
    }
}
