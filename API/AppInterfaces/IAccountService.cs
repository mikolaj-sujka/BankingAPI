using System.Threading.Tasks;
using API.DTOs;

namespace API.AppInterfaces
{
    public interface IAccountService
    {
        public Task<BankUserDto> Register(RegisterDto dto);
        public Task<BankUserDto> Login(LoginDto dto);
    }
}
