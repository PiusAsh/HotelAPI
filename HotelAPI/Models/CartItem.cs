using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public RoomModel Room { get; set; } = new RoomModel();
    }
}
