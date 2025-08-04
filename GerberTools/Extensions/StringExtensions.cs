using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerberTools.Extensions
{
    public static class StringExtensions
    {
        public static bool DoesContain(this string source, string target, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return source.Contains(target, stringComparison);
        }

        public static bool ContainsAll(this string source, params string[] targets) 
            => source.ContainsAll(StringComparison.InvariantCultureIgnoreCase, targets);

        public static bool ContainsAll(this string source, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase, params string[] targets)
        {
            foreach (var target in targets)
            {
                if (!source.DoesContain(target, stringComparison))
                    return false;
            }

            return true;
        }

        public static bool AreEqual(this string source, string target, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return source.Equals(target, stringComparison);
        }
    }
}
