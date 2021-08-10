using System.Threading.Tasks;
using API.AppInterfaces;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<BankUserDto>> Register(RegisterDto dto)
        {
            var newUser = await _accountService.Register(dto);
            if (newUser == null) return BadRequest("Username or Email is taken!");

            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<BankUserDto>> Login(LoginDto dto)
        {
            var userExists = await _accountService.Login(dto);
            if (userExists == null) return Unauthorized("User does not exist or " +
                                                      "Username/Password provided wrongly!");
            return Ok(userExists);
        }
    }
}
