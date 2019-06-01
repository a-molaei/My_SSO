using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper.Converter
{
    public static class EmailHelper
    {
        public static string ConvertToIncompleteAddress(string email)
        {
            var splittedEmail = email.Split('@');
            var begin = splittedEmail[0].Substring(0, 3);
            var end = splittedEmail[0].Substring(splittedEmail[0].Length - 2, 2);
            var result = $"{begin}...{end}@{splittedEmail[1]}";
            return result;
        }
    }
}
