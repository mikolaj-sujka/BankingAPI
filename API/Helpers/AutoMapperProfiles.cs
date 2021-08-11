using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, BankUser>()
                .ForMember(m => m.UserName,
                    c =>
                        c.MapFrom(s => s.UserName))
                .ForMember(m => m.FirstName,
                    c =>
                        c.MapFrom(s => s.FirstName))
                .ForMember(m => m.LastName,
                    c =>
                        c.MapFrom(s => s.LastName))
                .ForMember(m => m.City,
                    c =>
                        c.MapFrom(s => s.City))
                .ForMember(m => m.Country,
                    c =>
                        c.MapFrom(s => s.Country))
                .ForMember(m => m.DateOfBirth, 
                    c =>
                    c.MapFrom(s => s.DateOfBirth))
                .ForMember(m => m.PostalCode, 
                    c =>
                    c.MapFrom(s => s.PostalCode))
                .ForMember(m => m.Email, 
                    c =>
                    c.MapFrom(s => s.Email));

            CreateMap<RegisterDto, BankUserDto>()
                .ForMember(m => m.Username,
                    c =>
                        c.MapFrom(s => s.UserName));
        }
    }
}

