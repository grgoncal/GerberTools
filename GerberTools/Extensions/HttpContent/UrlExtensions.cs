using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GerberTools.Attributes;

namespace GerberTools.Extensions.HttpContent
{
    public static class UrlExtensions
    {
        public static string CreateQueryString(this object obj)
        {
            var sb = new StringBuilder();

            var urlParts = new List<string>();

            obj.FindAttribute<RestContentAttribute>((attr, value) =>
            {
                urlParts.Add($"{attr.Label}={value!}");
            });

            if (urlParts.Count == 0)
                return string.Empty;

            sb.Append('?')
                .Append(string.Join("&", urlParts));

            return sb.ToString();
        }
    }
}
