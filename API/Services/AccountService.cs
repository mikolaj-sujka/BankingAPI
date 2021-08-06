﻿using System.Threading.Tasks;
using API.AppInterfaces;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;
        private readonly IPasswordHasher<BankUser> _passwordHasher;
        private readonly IMapper _mapper;

        public AccountService(DataContext dataContext, IPasswordHasher<BankUser> passwordHasher, 
            IMapper mapper)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public async Task<BankUser> Register(RegisterDto dto)
        {

            if (await UserExists(dto.UserName, dto.Email)) return null;

            var user = _mapper.Map<BankUser>(dto);

            var newUser = new BankUser()
            {
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName.ToLower(),
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                Country = user.Country,
                Pin = user.Pin,
                PostalCode = user.PostalCode
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            return newUser;
        }

        public async Task<BankUser> Login(LoginDto dto)
        {
            var user = await _dataContext.Users
                .SingleOrDefaultAsync(x => x.UserName == dto.UserName);

            if (user == null) return null;

            var passwordComparison = _passwordHasher.
                VerifyHashedPassword(user, user.PasswordHash, user.Password);
            return passwordComparison == PasswordVerificationResult.Success ? user : null;
        }

        private async Task<bool> UserExists(string username, string email)
        {
            return await _dataContext.Users.AnyAsync(x => x.UserName == username.ToLower())
                   || await _dataContext.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}