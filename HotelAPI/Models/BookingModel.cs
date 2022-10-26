using HotelAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class BookingModel
    {
       public OrderModel Order { get; set; }
       public CartItemViewModel Item { get; set; }
    }
}
