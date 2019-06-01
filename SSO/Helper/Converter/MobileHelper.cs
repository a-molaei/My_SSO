using SSO.ViewModels.PasswordRecovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper.Converter
{
    public static class MobileHelper
    {
        public static string ConvertToIncompleteNumber(string mobileNumber)
        {
            var begin = mobileNumber.Substring(0, 4);
            var end = mobileNumber.Substring(mobileNumber.Length - 4, 4);
            var result = $"{begin}***{end}";
            return result;
        }

        public static MobileEncryptedAndIncompleteDto GetEncryptedAndIncompleteMobile(string mobileNumbers)
        {
            string incomplete = ConvertToIncompleteNumber(mobileNumbers);
            string encrypted = CryptographyHelper.Crypt(mobileNumbers);
            var result = new MobileEncryptedAndIncompleteDto()
            {
                IncompleteMobileNumber = incomplete,
                EncryptedMobileNumber = encrypted
            };
            return result;
        }
    }
}
