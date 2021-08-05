using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.AppInterfaces
{
    public interface IBankUserRepo
    {
        Task<ActionResult<IEnumerable<BankUser>>> GetUsersAsync();
        Task<ActionResult<BankUser>> GetUserByIdAsync(int id);
    }
}
