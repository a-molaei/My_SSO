﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSO.UoW;
using SSO.BLL;
using SSO.Helper.IbToken;
using SSO.ViewModels.IbToken;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSO.Controllers
{
    [Route("api/IbToken")]
    [ApiController]
    public class IbTokenController : BaseApiController
    {
        public IbTokenController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
            :base(unitOfWork, userManager, jwtHandler)
        {

        }

        [HttpGet]
        [Route("GetRandomKey")]
        public IActionResult GetRandomKey()
        {
            //var randomKey = TokenUtility.GetRandomHexKey();
            Random random = new Random();

            int[] randomKeys = new int[8];
            for (int i = 0; i < 8; i++)
                randomKeys[i] = random.Next(255);

            var res = TokenUtility.Fix8ArrayToHex(randomKeys);
           // return res;
            return Ok(new { RandomKey = res, Random = randomKeys });
        }

        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(IbTokenAuthenticate dto)
        {
            try
            {
                //UserAccount obj = DatabaseManagement.UserAccountManagement.ReadByUserName(userName);
                byte[] serialNumber = Encoding.ASCII.GetBytes("12346578"); ;
                int[] randomKeys = dto.RandomKeys;
                if (TokenUtility.CheckAlgorithm(randomKeys, serialNumber, dto.TokenResult))
                {
                    return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }

}