using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.AppInterfaces
{
    public interface ITokenService
    {
        public string CreateUserToken(BankUser bankUser);
    }
}
