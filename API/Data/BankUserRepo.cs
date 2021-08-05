using API.AppInterfaces;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class BankUserRepo : IBankUserRepo
    {
        private readonly DataContext _dataContext;

        public BankUserRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ActionResult<BankUser>> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<BankUser>>> GetUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }
    }
}
