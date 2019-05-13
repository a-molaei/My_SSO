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
    }
}
