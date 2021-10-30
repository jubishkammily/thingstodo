using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThingsToDoApi.Data;
using ThingsToDoApi.DTOs;
using ThingsToDoApi.Entities;

namespace ThingsToDoApi.Controllers
{
    public class UserController : CustomBaseApiController
    {

        private readonly DataContext _context;
       
        public UserController(DataContext context){

            _context = context;

        }

        [HttpGet("GetUsers")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.UserDetails.ToListAsync();
        }

        [HttpGet("GetUser")]
        [Authorize]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
             return await _context.UserDetails.FindAsync(id);
        }
        
    }
}