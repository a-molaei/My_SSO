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
    [Route("api/Setting")]
    [ApiController]
    public class SettingController : BaseApiController
    {
        public SettingController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
            :base(unitOfWork, userManager, jwtHandler)
        {

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var obj = UnitOfWork.SettingRepository.GetAll().FirstOrDefault();
            var dto = new SettingDto();
            if (obj != null)
                dto.SaveTo(obj);
                return Ok(dto);
        }


        [HttpPost]
        [Route("Set")]
        public IActionResult Set(SettingDto dto)
        {
            try
            {
                var obj = UnitOfWork.SettingRepository.GetAll().FirstOrDefault();
                if (obj == null)
                {
                    var entity = dto.LoadFrom();
                    UnitOfWork.SettingRepository.Add(entity);
                }
                else
                {
                    dto.CheckChanges(obj);
                }
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
