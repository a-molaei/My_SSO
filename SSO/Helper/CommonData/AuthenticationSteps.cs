using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Helper.CommonData
{
    public enum AuthenticationSteps
    {
        Login = 1,
        Mobile = 2,
        HardwareToken = 3,
        Done = 4
    }
}
