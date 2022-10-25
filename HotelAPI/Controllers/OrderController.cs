using HotelAPI.Context;
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
    public class OrderController : ControllerBase
    {
        private readonly HotelDbContext _context;
        public OrderController(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        [HttpGet("AllOrders")]
        public IActionResult AllOrder()
        {
            var orderDetails = _context.OrderModels.AsQueryable();
            return Ok(orderDetails);
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] OrderViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }
            else
            {
                var roomName = new List<int>();
                roomName.AddRange(viewModel.Items.Select(x => x.Room.Id));
                Random rd = new Random();
                int rand_num = rd.Next(1000000, 2000000);
                foreach (var roomId in roomName)
                {
                    var order = new OrderModel
                    {
                        User_Id = viewModel.Id,
                        Room_Id = roomId,
                        Status = viewModel.Status,
                        Payment_Id = "ASH"+ rand_num,
                        Total_Price = viewModel.TotalPrice,
                        Book_Date = viewModel.BookDate,
                      EndDate = viewModel.EndDate,
                      First_Name = viewModel.FirstName,
                      Last_Name = viewModel.LastName,
                      Phone = viewModel.Phone,
                      

                    };
                    _context.OrderModels.Add(order);
                };

                _context.SaveChanges();
                return Ok(new { Message = "Room Booked Successfully" });
            }
        }

        [HttpGet]
        [Route("GetOrderByPaymentId")]

        public async Task<IActionResult> GetOrderByPaymentId(string Id)
        {
            var order =
                await _context.OrderModels.FirstOrDefaultAsync(x => x.Payment_Id == Id);

            if (order == null)
            {
                return NotFound(new { Message = "Order does not exist" });

            }

            return Ok(order);
        }

        [HttpGet]
        [Route("GetOrderById")]

        public async Task<IActionResult> GetOrderById(int Id)
        {
            var order =
                await _context.OrderModels.FirstOrDefaultAsync(x => x.Id == Id);

            if (order == null)
            {
                return NotFound(new { Message = "Order does not exist" });

            }

            return Ok(order);
        }

        [HttpDelete]
        [Route("DeleteOrder")]

        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var order = await _context.OrderModels.FindAsync(Id);

            if (order == null)
            {
                return NotFound();
            }

            _context.OrderModels.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(new { Order = order.Payment_Id, Message = "Order Deleted Successfully" });

        }
    }
}
