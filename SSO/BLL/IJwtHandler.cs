using Microsoft.IdentityModel.Tokens;
using SSO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.BLL
{
    public interface IJwtHandler
    {
        JWT Create(string userId, int securityLevel);
        TokenValidationParameters Parameters { get; }
    }
}
