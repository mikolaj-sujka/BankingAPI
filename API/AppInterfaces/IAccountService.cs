using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.AppInterfaces
{
    public interface IAccountService
    {
        public Task<BankUser> Register(RegisterDto dto);
        public Task<BankUser> Login(LoginDto dto);
    }
}
