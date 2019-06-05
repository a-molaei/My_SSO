using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper.Validators
{
    public static class CustomValidator
    {
        public static bool ValidateMobileNumber(string mobileNumber)
        {
            if (mobileNumber.Length != 11)
            {
                return false;
            }
            if (mobileNumber.Substring(0, 1) != "0")
            {
                return false;
            }
            if (!new System.Text.RegularExpressions.Regex(@"^\d+$").IsMatch(mobileNumber))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateNationalCode(string nationalCode)
        {
            try
            {
                var allDigitEqual = new[]
                {
                    "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666",
                    "7777777777", "8888888888", "9999999999"
                };
                if (allDigitEqual.Contains(nationalCode)) return false;


                var chArray = nationalCode.ToCharArray();
                var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
                var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
                var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
                var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
                var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
                var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
                var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
                var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
                var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
                var a = Convert.ToInt32(chArray[9].ToString());

                var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
                var c = b % 11;

                return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckPasswordComplexity(string password)
        {
            var rule1 = password.Any(char.IsLetter);
            var rule2 = password.Any(char.IsNumber);
            var rule3 = password.Length >= 8;
            var res = (rule1 && rule2 && rule3);
            return res;
        }

    }
}
