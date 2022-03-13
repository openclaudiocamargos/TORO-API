using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commom.Helpers
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string value)
        {
            return new String(value.Where(Char.IsDigit).ToArray());
        }
    }
}
