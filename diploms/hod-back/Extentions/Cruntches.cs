using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Extentions
{
    public static class Cruntches
    {
        public static string NewFgos(this string value)
        {
            if (value.Contains("2.2")) { return "4.4.3"; }
            if (value.Contains("2.4")) { return "4.4.4"; }
            if (value.Contains("2.3")) { return "4.4.5"; }
            return value;
        }
    }
}
