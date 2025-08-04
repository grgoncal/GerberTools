using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerberTools.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsDefault(this object src)
        {
            var type = src.GetType();

            if (type.IsValueType)
                return Activator.CreateInstance(type)!.Equals(src);

            return false;
        }
    }
}
