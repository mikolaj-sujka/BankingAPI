using System.Threading.Tasks;
using API.AppInterfaces;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _dataContext;
        private readonly IPasswordHasher<BankUser> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountService(DataContext dataContext, IPasswordHasher<BankUser> passwordHasher, 
            IMapper mapper, ITokenService tokenService)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<BankUserDto> Register(RegisterDto dto)
        {

            if (await UserExists(dto.UserName, dto.Email)) return null;

            var user = _mapper.Map<BankUser>(dto);

            var newUser = new BankUser()
            {
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName.ToLower(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                Country = user.Country,
                PostalCode = user.PostalCode,
                CreditCard = new CreditCard()
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            await _dataContext.Users.AddAsync(newUser);
            await _dataContext.SaveChangesAsync();

            return new BankUserDto()
            {
                Token = _tokenService.CreateUserToken(newUser),
                Username = newUser.UserName
            };
        }

        public async Task<BankUserDto> Login(LoginDto dto)
        {
            var user = await _dataContext.Users
                .SingleOrDefaultAsync(x => x.UserName == dto.UserName.ToLower());

            if (user == null) return null;

            var passwordComparison = _passwordHasher.
                VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (passwordComparison == PasswordVerificationResult.Success)
                return new BankUserDto()
                {
                    Token = _tokenService.CreateUserToken(user),
                    Username = user.UserName
                };
            else
                return null;
        }

        public async Task<BankUser> DeleteAcc(string username)
        {
            var user = await _dataContext.Users
                .SingleOrDefaultAsync(x => x.UserName == username.ToLower());
            if (user == null) return null;

            _dataContext.Remove(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }


        private async Task<bool> UserExists(string username, string email)
        {
            return await _dataContext.Users.AnyAsync(x => x.UserName == username.ToLower())
                   || await _dataContext.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
