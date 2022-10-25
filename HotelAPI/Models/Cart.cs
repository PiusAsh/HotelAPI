using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public UserModel User { get; set; } = new UserModel();
        public List<CartItem> CartItems { get; set; } =  new List<CartItem>();

    }
}
