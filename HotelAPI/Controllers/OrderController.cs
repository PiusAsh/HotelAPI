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
    public class OrderController : Controller
    {
        private readonly HotelDbContext _context;
        public OrderController(HotelDbContext hotelDbContext)
        {
            _context = hotelDbContext;
        }

        //[HttpGet("AllOrders")]
        //public JsonResult AllOrder()
        //{
        //    var orderDetails = _context.OrderModels.ToList().OrderByDescending(x => x.Id);
        //    return Json(orderDetails);
        //}

        [HttpGet("AllOrders")]
        public IActionResult AllOrder()
        {
            var orderDetails = _context.OrderModels.OrderByDescending(x => x.Id).AsQueryable();
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
                foreach (var item in viewModel.Items)
                {
                    //Random rd = new Random();
                    //int rand_num = rd.Next(1000000, 2000000);

                    var order = new OrderModel
                    {


                        Room = _context.RoomModels.Find(item.Room.Id),
                        User = _context.UserModels.Find(viewModel.Id),
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        Phone = viewModel.Phone,
                        Days = item.Days,
                        RoomPrice = item.Price,
                        Payment_Id = viewModel.PaymentId,
                        StartDate = item.StartDate
                      
                        //StartDate = item.StartDate,
                        //CheckOutDate = item.CheckOutDate
                    };
                    _context.OrderModels.Add(order);

                }

                _context.SaveChanges();
                return Ok(new { Message = "Room Booked Successfully" });

            }
        }

        [HttpGet]
        [Route("GetOrderByPaymentId")]

        public async Task<IActionResult> GetOrderByPaymentId(string paymentId)
        {
            var order =
                await _context.OrderModels.FirstOrDefaultAsync(x => x.Payment_Id == paymentId);

            if (order == null)
            {
                return NotFound(new { Message = "Order does not exist" });

            }
            return Ok(new BookingModel
            {
                Order = order,
                Item = new CartItemViewModel
                {
                    Days = order.Days,
                    Price = order.RoomPrice,
                    Room = (HotelViewModel)_context.RoomModels.Where(x => x.Id == order.Room.Id).Select(x => new HotelViewModel
                    {
                        RoomName = x.RoomName,
                        RoomPrice = x.RoomPrice,
                    }),
                }

            });
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


        [HttpGet]
        [Route("GetUserOrder")]

        public async Task<IActionResult> GetUserOrder(int userId)
        {
            var user = await _context.UserModels.FindAsync(userId);
            var recentRoom = await _context.OrderModels.Where(x => x.User == user).OrderByDescending(x => x.Id).Select(x => x.Room.RoomName).FirstOrDefaultAsync();

            var orderCount = await _context.OrderModels.Where(x => x.User.Id == userId).CountAsync();

            if (recentRoom == null || orderCount == 0)
            {
                return NotFound(new { Message = "Order does not exist" });

            }

            return Ok(new
            {
                recentRoom,
                orderCount
            });
        }


        [HttpGet]
        [Route("GetAllUserOrders")]

        public async Task<IActionResult> GetAllUserOrders(int userId)
        {
            var user = await _context.UserModels.FindAsync(userId);
            //var recentRoom = await _context.OrderModels.Where(x => x.User == user).OrderByDescending(x => x.Id).Select(x => x.Room).FirstOrDefaultAsync();
            //var recentRoom = await _context.OrderModels.Where(x => x.User == user).Select(x => x).FirstOrDefaultAsync();
            var userRooms = await _context.OrderModels.Where(x => x.User == user).Select(x => new OrderModel
            {
Id = x.Id,
Payment_Id = x.Payment_Id,
Days = x.Days,
RoomPrice = x.RoomPrice,
Room = x.Room,
Status = x.Status
            }).OrderByDescending( x => x.Id).ToListAsync();

            if (userRooms == null )
            {
                return NotFound(new { Message = "No booking list found" });

            }

            return Ok(new
            {
                userRooms,
                
            });
        }


        [HttpGet("searchPaymentId")]
        public async Task<JsonResult> GetTransactionsBy3(string search)
        {
            var trans = await _context.OrderModels.Where(p => p.Payment_Id == search).ToListAsync();

            return new JsonResult(trans);

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
