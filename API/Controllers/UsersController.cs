﻿using API.AppInterfaces;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IBankUserRepository _userRepo;

        public UsersController(IBankUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            return Ok(await _userRepo.GetMembersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUserById(int id)
        {
            return await _userRepo.GetMemberByIdAsync(id);
        }

        [HttpGet("name/{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
        {
            return await _userRepo.GetMemberAsync(username);
        }
    }
}
