using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSO.UoW;
using SSO.BLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSO.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private IUnitOfWork _UnitOfWork;
        private IUserManager _UserManager;
        private IJwtHandler _JwtHandler;
        protected BaseApiController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
        {
            _UnitOfWork = unitOfWork;
            _UserManager = userManager;
            _JwtHandler = jwtHandler;
        }
        protected IUnitOfWork UnitOfWork => _UnitOfWork;
        protected IUserManager UserManager => _UserManager;
        protected IJwtHandler JwtHandler => _JwtHandler;
        protected int SecurityLevel {
            get
            {
                if (!IsTokenTimeValid)
                    return 0;
                return Convert.ToInt32(User.Claims.FirstOrDefault(u => u.Type == "security_level")?.Value ?? "0");
            }
        }
        public bool IsTokenTimeValid
        {
            get
            {
                var nowUtc = DateTime.UtcNow;
                var centuryBegin = new DateTime(1970, 1, 1);
                var currentSeconds = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
                var nbf = Convert.ToInt64(User.Claims.FirstOrDefault(u => u.Type == "nbf")?.Value);
                var exp = Convert.ToInt64(User.Claims.FirstOrDefault(u => u.Type == "exp")?.Value);
                if (currentSeconds >= nbf && currentSeconds <= exp)
                    return true;
                else
                    return false;
            }
        }
        public string UserId
        {
            get
            {
                return UnitOfWork.UserRepository.Find(u => u.UserName == User.Identity.Name).FirstOrDefault()?.Id;
            }
        }
    }
}
