using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper.IbToken
{
    public static class TokenUtility
    {
        public static string GetRandomHexKey()
        {
            Random random = new Random();

            int[] randomKeys = new int[8];
            for (int i = 0; i < 8; i++)
                randomKeys[i] = random.Next(255);

            var res = Fix8ArrayToHex(randomKeys);
            return res;
        }
        public static bool CheckAlgorithm(int[] randomKeys, byte[] serialNumber, string hardwareTokenResult)
        {
            int i, j, temp, t, t1;
            int[] InCal = new int[8];

            temp = 0;
            for (i = 1; i <= 100; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    temp = TokenAlgorithm((temp + randomKeys[j] + serialNumber[j]) % 256);
                    InCal[j] = temp;
                }
                t = (InCal[0]) & 7;
                t1 = InCal[t];
                InCal[t] = InCal[0];
                InCal[0] = t1;
            }

            string softwareTokenResult = Fix8ArrayToHex(InCal);
            if (softwareTokenResult == hardwareTokenResult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int TokenAlgorithm(int InNum)
        {
            //------------------------------------------
            //Send Algorithm
            //------------------------------------------

            int RetVal;
            if ((InNum % 2) == 0)
                RetVal = (int)(Math.Round(110 * Math.Exp(Math.Sin(4 + Math.Log((1 + (double)InNum) / 300))) - 40));
            else
                RetVal = (int)(Math.Round(256 - (110 * Math.Exp(Math.Sin(4 + Math.Log((256 - (double)InNum) / 300))) - 40)));
            return (512 + RetVal) % 256;

            //------------------------------------------
            //First Algorithm
            //------------------------------------------

            //if ((InNum % 2) == 0)
            //    return (int)System.Math.Floor((double)(System.Math.Tan(3.14 * (double)(90 - System.Math.Log((double)InNum / 1000 + 1)) / 180) - 210) / 4.1);
            //else
            //    return (int)System.Math.Floor(255 - (double)(System.Math.Tan(3.14 * (double)(90 - System.Math.Log((double)InNum / 1000 + 1)) / 180) - 210) / 4.1);
        }
        public static string Fix8ArrayToHex(int[] array)
        {
            if (array.Length == 8)
            {
                int[] result = new int[4];
                result[0] = array[1] * 256 + array[0];
                result[1] = array[3] * 256 + array[2];
                result[2] = array[5] * 256 + array[4];
                result[3] = array[7] * 256 + array[6];
                return DecimalToHex(result[0], 4) + DecimalToHex(result[1], 4) + DecimalToHex(result[2], 4) + DecimalToHex(result[3], 4);
            }
            else
            {
                throw new Exception("Array parameter must be have 8 item .");
            }
        }
        public static string DecimalToHex(int data, int padding)
        {
            string hex = data.ToString("X");
            while (hex.Length < padding)
            {
                hex = "0" + hex;
            }
            return hex;
        }
    }
}
