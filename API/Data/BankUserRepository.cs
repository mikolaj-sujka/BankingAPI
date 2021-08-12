using API.AppInterfaces;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class BankUserRepository : IBankUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BankUserRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BankUser> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users
                .Include(p => p.CreditCard)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<BankUser> GetUserByUsernameAsync(string username)
        {
            return await _dataContext.Users
                .Include(u => u.CreditCard)
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _dataContext.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _dataContext.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            return await _dataContext.Users
                .Where(x => x.Id == id)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public void Update(BankUser bankUser)
        {
            _dataContext.Entry(bankUser).State = EntityState.Modified;
        }

        public async Task<IEnumerable<BankUser>> GetUsersAsync()
        {
            return await _dataContext.Users
                .Include(u => u.CreditCard)
                .ToListAsync();
        }
    }
}
