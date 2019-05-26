using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SSO.Helper.Sms
{
    public class SmsService
    {
        public bool SendVerificationCode(string mobileNumber, string code)
        {

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest
                .Create("https://api.kavenegar.com/v1/6E67774E6B4547614172573159776D444B6D72706D334B4A56637A3236645159/verify/lookup.json?receptor=" + mobileNumber + "&token=" + code + "&template=verify");
            objRequest.Method = "GET";

            WebResponse response = (WebResponse)objRequest.GetResponse();
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static bool SendSms(List<string> mobileNumbers, string message)
        {
            mobileNumbers.RemoveAll(m => string.IsNullOrEmpty(m));
            string mobileNumberJoined = string.Join(",", mobileNumbers);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest
                .Create("https://api.kavenegar.com/v1/6E67774E6B4547614172573159776D444B6D72706D334B4A56637A3236645159/sms/send.json?receptor=" + mobileNumberJoined + "&message=" + message);
            objRequest.Method = "GET";

            WebResponse response = (WebResponse)objRequest.GetResponse();
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;

        }
    }
}
