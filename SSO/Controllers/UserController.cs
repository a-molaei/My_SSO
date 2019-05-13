using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSO.ViewModels;
using SSO.UoW;
using SSO.BLL;
using Microsoft.AspNetCore.Authorization;

namespace SSO.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
            :base(unitOfWork, userManager, jwtHandler)
        {

        }
        // GET api/values
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserCreateDto dto)
        {
            var result = UserManager.CreateUser(dto);
            return new ObjectResult(result);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return new ObjectResult(1);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserCredentialsDto dto)
        {
            var result = UserManager.Authenticate(dto.UserName, dto.Password);
            if (result == "Failed")
            {
                return Unauthorized();
            }
            return new ObjectResult(JwtHandler.Create(dto.UserName));
        }

    }
}
