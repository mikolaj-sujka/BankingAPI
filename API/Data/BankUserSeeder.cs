using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public class BankUserSeeder 
    {
        private readonly DataContext _dataContext;

        public BankUserSeeder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedUsers()
        {
            if (!_dataContext.Users.Any())
            {
                var users = CreateUsers();
                await _dataContext.Users.AddRangeAsync(users);
                await _dataContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<BankUser> CreateUsers()
        {
            var users = new List<BankUser>()
            {
                new BankUser()
                {
                    UserName = "alex123",
                    City = "Barcelona",
                    Country = "Spain",
                    CreditCard = new CreditCard()
                    {
                        DateExpires = new DateTime(2024, 11, 1)
                    },
                    DateOfBirth = new DateTime(1999, 10, 2),
                    Email = "test@test.com",
                    FirstName = "Alexander",
                    LastName = "Gustaf",
                    PasswordHash = " $2a$12$67.bAQvDAe91e/qR2TMZhu3EQIX9JjKsUXefApbolC3IYW9cVgLKW ",
                    Pin = "1111",
                    PostalCode = "33-209"
                },
                new BankUser()
                {
                    UserName = "TomX12",
                    City = "Madrid",
                    Country = "Spain",
                    CreditCard = new CreditCard()
                    {
                        DateExpires = new DateTime(2027, 9, 3)
                    },
                    DateOfBirth = new DateTime(1973, 11, 23),
                    Email = "test@o23.com",
                    FirstName = "Tom",
                    LastName = "Dom",
                    PasswordHash = " $2a$12$R1Fm7MBmt5MXEtZr0woK0.tbY8JGZIUqbxzJ8wT.bL1OoKkm3UBCu",
                    Pin = "3215",
                    PostalCode = "28-112"
                }
            };
            return users;
        }
    }
}
