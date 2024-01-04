using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Common.Extensions
{
    public static class StringExtentions
    {

        public static string ToControllerName(this string value)
        {
            return !string.IsNullOrEmpty(value) ? value.ToLower().Replace("controller", string.Empty) : value;
        }

    }

}
