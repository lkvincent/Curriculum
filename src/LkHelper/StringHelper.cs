using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkHelper
{
    public static class StringHelper
    {
        public static string Cut(this string input, int maxLength, string shortString)
        {
            if (string.IsNullOrEmpty(input)) return "";
            if (input.Length <= maxLength) return input;
            return input.Substring(0, maxLength) + (string.IsNullOrEmpty(shortString) ? "...." : shortString);
        }

        public static string Cut(this string input, bool enableShortContent, int maxLength, string shortString = "...")
        {
            if (!enableShortContent) return input;
            if (String.IsNullOrEmpty(input)) return "";
            return input.Cut(maxLength, shortString);
        }
    }
}
