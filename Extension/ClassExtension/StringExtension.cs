using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExtension
{
    public static class StringExtension
    {
        public static string Quot(this string str)
        {
            return $"\'{str}\'";
        }
    }
}
