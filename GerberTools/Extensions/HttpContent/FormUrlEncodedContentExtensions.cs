using System.Collections.Generic;
using System.Net.Http;
using GerberTools.Attributes;
using GerberTools.Extensions;

namespace GerberTools.Extensions.HttpContent
{
    public static class FormUrlEncodedContentExtensions
    {
        public static FormUrlEncodedContent CreateFormUrlEncodedContent(this object source)
        {
            var content = new List<KeyValuePair<string, string>>();

            source.FindAttribute<RestContentAttribute>((attr, value) =>
            {
                content.Add(new KeyValuePair<string, string>(attr.Label, value.ToString()!));
            });

            return new FormUrlEncodedContent(content);
        }
    }
}
