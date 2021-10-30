using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThingsToDoApi.Data;
using ThingsToDoApi.DTOs;
using ThingsToDoApi.Entities;
using ThingsToDoApi.Interfaces;

namespace ThingsToDoApi.Controllers
{
    [ApiController]
  
    public class ProfileController : CustomBaseApiController
    {

        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public ProfileController(DataContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [Route("Register")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> Register(string username, string password){
            using var hmac = new HMACSHA512();

            if(await userExist(username)) 
            return BadRequest("Username already exist");

            var user = new User(){
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.UserDetails.Add(user);
             await _context.SaveChangesAsync();

            return new UserDto{
                UserName = username,
                Token = _tokenService.CreateToken(user)
            };

        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDTO loginDto){

            var user = await _context.UserDetails.SingleOrDefaultAsync(x => x.UserName ==  loginDto.UserName);

            if(user == null)
            return Unauthorized("Invalid User");

             using var hmac = new HMACSHA512(user.PasswordSalt);
             var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)); 

            //  foreach(var i in hash){}

            for(var i = 0; i < hash.Length; i++){
                if(hash[i]!= user.PasswordHash[i]) return Unauthorized("Unauthorized User");
            }

             return new UserDto{
                UserName = loginDto.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }




        private async Task<bool> userExist(string username){      
            //  return await _context.UserDetails.AnyAsync(x=>x.UserName.ToLower() == username.ToLower()); 
            return await _context.UserDetails.AnyAsync(x=>x.UserName == username); 
            }
        
    }
}