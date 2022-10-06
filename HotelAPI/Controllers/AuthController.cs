using HotelAPI.Context;
using HotelAPI.Models;
using HotelAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public AuthController(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }
        [HttpGet("RegisteredUsers")]
        public IActionResult RegisteredUser()
        {
            var userDetails = _context.UserModels.AsQueryable();
            return Ok(userDetails);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserViewModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = new UserModel
                {
                    Address = userObj.Address,
                    Email = userObj.Email,
                    PhoneNo = userObj.PhoneNo,
                    Password = userObj.Password,
                    DateOfBirth = userObj.DateOfBirth,
                    Gender = userObj.Gender,
                    Country = userObj.Country,
                    FirstName = userObj.FirstName,
                    LastName = userObj.LastName,
                    State = userObj.State

                };
                _context.UserModels.Add(user);
                _context.SaveChanges();
                return Ok(new { Message = "User Added Successfully",
                    UserData = user.Id
                });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.UserModels.Where(a => a.Email == model.Email && a.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(new
                    {
                        Message = "Logged In Successfully",
                        UserData = user.Id
                    });
                }
                else
                {
                    return NotFound(new { Mesage = "User Does not exist" });
                }
            }
        }


        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int Id, UserViewModel userObj)
        {
            var user = await _context.UserModels.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {

                user.Address = userObj.Address;
                user.Email = userObj.Email;
                user.PhoneNo = userObj.PhoneNo;
                user.Password = userObj.Password;
                user.DateOfBirth = userObj.DateOfBirth;
                user.Gender = userObj.Gender;
                user.Country = userObj.Country;
                user.FirstName = userObj.FirstName;
                user.LastName = userObj.LastName;
                user.State = userObj.State;


                await _context.SaveChangesAsync();

                return Ok(user);
            }
        }


            [HttpDelete]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _context.UserModels.FindAsync(Id);

            if (user == null)
            {
                return NotFound();
            }

            _context.UserModels.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { Room = user.FirstName , Message = "Room Deleted Successfully" });

        }


        [HttpGet]
        [Route("GetUserById")]

        public async Task<IActionResult> GetUserById(int Id)
        {
            var user =
                await _context.UserModels.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
            {
                return NotFound(new { Message = "User does not exist" });

            }

            return Ok(user);
        }
    }
}
