using HotelAPI.Context;
using HotelAPI.Helper;
using HotelAPI.Models;
using HotelAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public static string HashedPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);
            var hexString = BitConverter.ToString(hashedpassword);
            return hexString;
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

                //userObj.Password = PasswordHasher.HashPassword(userObj.Password);
                var user = new UserModel
                {
                    Address = userObj.Address,
                    Email = userObj.Email,
                    PhoneNo = userObj.PhoneNo,
                    Password = HashedPassword(userObj.Password),
                    DateOfBirth = userObj.DateOfBirth,
                    Gender = userObj.Gender,
                    Country = userObj.Country,
                    FirstName = userObj.FirstName,
                    LastName = userObj.LastName,
                    State = userObj.State,
                    IsAdmin = userObj.IsAdmin

                };
                //userObj.Password = PasswordHasher.HashPassword(userObj.Password);
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
                var user = _context.UserModels.Where(a => a.Email == model.Email && a.Password == HashedPassword(model.Password)).FirstOrDefault();
                if (HashedPassword(model.Password) == user.Password)
                {
                    return Ok(new
                    {
                        Message = "Logged In Successfully",
                        UserData = user.Id,
                        Admin = user.IsAdmin,
                        Email = user.Email
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
