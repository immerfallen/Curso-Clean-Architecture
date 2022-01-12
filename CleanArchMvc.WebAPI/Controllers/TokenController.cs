﻿using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;

        public TokenController(IAuthenticate authentication)
        {
            _authentication = authentication ?? 
                throw new ArgumentNullException(nameof(authentication));
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

            if(result)
            {
                // return GenerateToken(userInfo);
                return Ok($"User: {userInfo.Email} Login Successfully.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return BadRequest(ModelState);
            }
        }
    }
}
