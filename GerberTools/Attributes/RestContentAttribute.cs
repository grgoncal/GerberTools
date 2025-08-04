using System;
namespace GerberTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RestContentAttribute : Attribute
    {
        public string Label { get; }

        public RestContentAttribute(string label)
        {
            Label = label;
        }
    }
}
