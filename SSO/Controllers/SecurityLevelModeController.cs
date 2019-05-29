using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSO.UoW;
using SSO.BLL;
using SSO.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSO.Controllers
{
    [Route("api/SecurityLevelMode")]
    [ApiController]
    public class SecurityLevelModeController : BaseApiController
    {
        public SecurityLevelModeController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
            :base(unitOfWork, userManager, jwtHandler)
        {

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = UnitOfWork.SecurityLevelModelRepository.GetAll()
                .Select(s => {
                    var dto = new SecurityLevelModeDto();
                    dto.SaveTo(s);
                    return dto; });
            return Ok(result);
        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set(SecurityLevelModeCreateListDto dto)
        {
            try
            {
                var list = dto.List.Select(s => s.LoadFrom());
                var all = UnitOfWork.SecurityLevelModelRepository.GetAll();
                UnitOfWork.SecurityLevelModelRepository.RemoveRange(all);
                UnitOfWork.SecurityLevelModelRepository.AddRange(list);
                UnitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}
