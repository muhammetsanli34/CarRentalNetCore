using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.Register(userForRegisterDto,userForRegisterDto.Password);
            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest(registerResult.Message);
        }
        
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var loginResult = _authService.Login(userForLoginDto);
            var result = _authService.CreateAccessToken(loginResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

    }
}
