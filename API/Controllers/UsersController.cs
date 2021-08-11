using API.AppInterfaces;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IBankUserRepo _userRepo;

        public UsersController(IBankUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankUser>>> GetUsers()
        {
            return await _userRepo.GetUsersAsync();
        }

        [Authorize]
        // api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<BankUser>> GetUserById(int id)
        {
            var user = _userRepo.GetUserByIdAsync(id);
            return await user;
        }
    }
}
