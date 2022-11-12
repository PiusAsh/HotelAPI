using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models.ViewModels
{
    public class CartItemViewModel
    {
        
        public int Days { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public HotelViewModel Room { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime CheckOutDate { get; set; }
    }
}
