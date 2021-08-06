using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.AppInterfaces;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly DataContext _dataContext;

        public AccountController(IAccountService accountService, DataContext dataContext)
        {
            _accountService = accountService;
            _dataContext = dataContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<BankUser>> Register(RegisterDto dto)
        {
            var newUser = await _accountService.Register(dto);
            if (newUser == null) return BadRequest("Username or Email is taken!");

            await _dataContext.Users.AddAsync(newUser);
            await _dataContext.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<BankUser>> Login(LoginDto dto)
        {
            var userExists = await _accountService.Login(dto);
            if (userExists == null) return BadRequest("User does not exist or " +
                                                      "Username/Password provided wrongly!");
            return Ok("Successfully logged in!");
        }
    }
}
