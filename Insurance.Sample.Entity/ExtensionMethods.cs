using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Entity
{
    public static class ExtensionMethods
    {
        public static string ReplaceInvalidCharsAndToUpper(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return value.Trim().Replace(" ", "").ToUpper();
        }
    }
}
