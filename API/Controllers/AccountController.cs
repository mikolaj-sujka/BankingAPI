using System.Security.Claims;
using System.Threading.Tasks;
using API.AppInterfaces;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IBankUserRepository _bankUserRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IBankUserRepository bankUserRepository,
            IMapper mapper)
        {
            _accountService = accountService;
            _bankUserRepository = bankUserRepository;
            _mapper = mapper;
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

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto member)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _bankUserRepository.GetUserByUsernameAsync(username);

            _mapper.Map(member, user);
            _bankUserRepository.Update(user);

            if (await _bankUserRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpDelete("delete/{username}")]
        public async Task<ActionResult> DeleteUser(string username)
        {
            if (await _accountService.DeleteAcc(username) != null)
                return Ok("User successfully deleted!");
            return NotFound();
        }
    }
}
