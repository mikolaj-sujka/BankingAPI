using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.AppInterfaces
{
    public interface IBankUserRepository
    {
        void Update(BankUser bankUser);
        Task<IEnumerable<BankUser>> GetUsersAsync();
        Task<BankUser> GetUserByIdAsync(int id);
        Task<bool> SaveAllAsync();
        Task<BankUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
        Task<MemberDto> GetMemberByIdAsync(int id);
    }
}
