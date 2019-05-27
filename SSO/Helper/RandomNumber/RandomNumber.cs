using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper
{
    public class RandomNumber
    {
        public string GenerateRandomNumber(int count)
        {
            Random rand = new Random();
            string num = "";
            for (int i = 0; i < count; i++)
            {
                num += rand.Next(10);
            }
            return num;
        }
    }
}
