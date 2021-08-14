using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.AppInterfaces
{
    public interface IAccountService
    {
        public Task<BankUserDto> Register(RegisterDto dto);
        public Task<BankUserDto> Login(LoginDto dto);
        public Task<BankUser> DeleteAcc(string username);
    }
}
