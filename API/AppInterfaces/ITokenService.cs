using API.Entities;

namespace API.AppInterfaces
{
    public interface ITokenService
    {
        public string CreateUserToken(BankUser bankUser);
    }
}
