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
    public class HotelRoomController : ControllerBase

    {
        private readonly HotelDbContext _context;
        public HotelRoomController(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }
        [HttpGet("GetAllRooms")]
        public IActionResult GeAllRooms()
        {
            var roomDetails = _context.RoomModels.AsQueryable();
            return Ok(roomDetails);
        }

        [HttpPost("AddRoom")]
        public IActionResult AddRoom([FromBody] HotelViewModel roomObj)
        {
            if(roomObj == null)
            {
                return BadRequest();
            }
            else
            {
                var room = new RoomModel
                {
                    RoomName = roomObj.RoomName,
                    RoomType = roomObj.RoomType,
                    RoomDes = roomObj.RoomDes,
                    RoomImg = roomObj.RoomImg,
                    RoomPrice = roomObj.RoomPrice
                };
                _context.RoomModels.Add(room);
                _context.SaveChanges();
                return Ok(new { Message = "Room Added Successfully" });
            }
        }

        [HttpGet]
        [Route("GetRoomById")]

        public async Task<IActionResult> GetRoomById(int Id)
        {
            var room =
                await _context.RoomModels.FirstOrDefaultAsync(x => x.Id == Id);

            if (room == null)
            {
                return NotFound(new {Message = "Room does not exist" });

            }

            return Ok(room);
        }


        [HttpPut]
        [Route("UpdateRoom")]
        public async Task<IActionResult> UpdateGuest(int Id, HotelViewModel roomObj)
        {
            var room = await _context.RoomModels.FindAsync(Id);
            if (room == null)
            {
                return NotFound();
            }
            else
            {
                room.RoomName = roomObj.RoomName;
                room.RoomType = roomObj.RoomType;
                room.RoomDes = roomObj.RoomDes;
                room.RoomImg = roomObj.RoomImg;
                room.RoomPrice = roomObj.RoomPrice;


                 await _context.SaveChangesAsync();

                return Ok(room);
            }
             
        }
        [HttpDelete]
        [Route("DeleteRoom")]

        public async Task<IActionResult> DeleteRoom(int Id)
        {
            var room = await _context.RoomModels.FindAsync(Id);

            if (room == null)
            {
                return NotFound();
            }

            _context.RoomModels.Remove(room);
            await _context.SaveChangesAsync();

            return Ok(new { Room = room.RoomName, Message = "Room Deleted Successfully" });

        }

    }
}


