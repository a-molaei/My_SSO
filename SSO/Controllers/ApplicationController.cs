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
    [Route("api/Application")]
    [ApiController]
    public class ApplicationController : BaseApiController
    {
        public ApplicationController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
            :base(unitOfWork, userManager, jwtHandler)
        {

        }

        [Route("GetUrlById/{id}")]
        [HttpGet]
        public IActionResult GetUrlById(int id)
        {
            var app = UnitOfWork.ApplicationRepository.Get(id);
            if (app == null)
                return NotFound();
            return Ok(new { Url = app.Url });
        } 
    }
}
